using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[CreateAssetMenu(fileName = "Gun", menuName = "Guns/Gun", order = 0)]
public class GunScriptableObject : ScriptableObject, System.ICloneable
{
    public ImpactType ImpactType;
    public GunType Type;
    public string Name;
    public GameObject ModelPrefab;
    public Vector3 SpwanPoint;
    public Vector3 SpawnRotation;

    public AmmoConfigScriptableObject AmmoConfig;
    public DamageConfigScriptableObject DamageConfig;
    public ShootConfigScriptableObject ShootConfig;
    public TrailConfigScriptableObject TrailConfig;
    public AudioConfigScriptableObject AudioConfig;

    private MonoBehaviour ActiveMonoBehaviour;
    private GameObject Model;
    private AudioSource ShootingAudioSource;
    private float LastShootTime;
    private ParticleSystem ShootSystem;
    private ObjectPool<Bullet> BulletPool;
    private ObjectPool<TrailRenderer> TrailPool;
    private bool LastFrameWantedToShoot = false;
    private float StopShootingTime = 0.0f;

    public void Spawn(Transform Parent, MonoBehaviour ActiveMonoBehaviour)
    {
        Debug.Log("GunScriptbale SPAWN"); 
        this.ActiveMonoBehaviour = ActiveMonoBehaviour;
        LastShootTime = 0;
        TrailPool = new ObjectPool<TrailRenderer>(CreateTrail);
        if(!ShootConfig.IsHitscan)
        {
            BulletPool = new ObjectPool<Bullet>(CreateBullet);
        }
        Model = Instantiate(ModelPrefab);
        Model.transform.SetParent(Parent, false);
        Model.transform.localPosition = SpwanPoint;
        Model.transform.localRotation = Quaternion.Euler(SpawnRotation);

        ShootSystem = Model.GetComponentInChildren<ParticleSystem>();
        ShootingAudioSource = Model.GetComponent<AudioSource>();
        if (!ShootingAudioSource)
        {
           Debug.Log("AUDIOSOURCE NO ENCONTRADA"); 
        }
    }

    public void Despawn()
    {
        Model.SetActive(false);
        Destroy(Model);
        TrailPool.Clear();
        if (BulletPool != null)
        {
            BulletPool.Clear();
        }

        ShootingAudioSource = null;
        ShootSystem = null;
    }
    private void TryToShoot()
    {
        /*
        if (Time.time - LastShootTime - ShootConfig.FireRate > Time.deltaTime)
        {
            float lastDuration = Mathf.Clamp(
                0,
                (StopShootingTime - InitialClickTime),
                ShootConfig.MaxSpreadTime
            );
            float lerpTime = (ShootConfig.RecoilRecoverySpeed - (lerpTime.time - StopShootingTime))
                                / ShootConfig.RecoilRecoverySpeed;
            
            float lerpTime = 0.1f;

            InitialClickTime = Time.time - Mathf.Lerp(0, lastDuration, Mathf.Clamp01(lerpTime));
        }*/

        if(Time.time > ShootConfig.FireRate + LastShootTime)
        {
            LastShootTime = Time.time;
            if(AmmoConfig.CurrentClipAmmo == 0)
            {
                AudioConfig.PlayOutOfAmmoClip(ShootingAudioSource);
                return;
            }

            ShootSystem.Play();
            AudioConfig.PlayShootingClip(ShootingAudioSource, AmmoConfig.CurrentClipAmmo == 1);

            AmmoConfig.CurrentClipAmmo--;

            if(ShootConfig.IsHitscan)
            {
                Shoot();
            }
            else
            {
                ProjectileShoot();
            }
        }
        
    }
    public void Shoot()
    {
        LastShootTime = Time.time;
        ShootSystem.Play();
        AudioConfig.PlayShootingClip(ShootingAudioSource, AmmoConfig.CurrentClipAmmo == 1);

        Vector3 shootDirection = ShootSystem.transform.forward;
            /*+ new Vector3(
                Random.Range(
                    -ShootConfig.Spread.x,
                    ShootConfig.Spread.x
                ),
                Random.Range(
                    -ShootConfig.Spread.y,
                    ShootConfig.Spread.y
                ),
                Random.Range(
                    -ShootConfig.Spread.z,
                    ShootConfig.Spread.z
                )
            );*/
            
        AmmoConfig.CurrentClipAmmo--;

        shootDirection.Normalize();

        if(Physics.Raycast(
            ShootSystem.transform.position,
            shootDirection,
            out RaycastHit hit,
            float.MaxValue,
            ShootConfig.HitMask
        ))
        {
            ActiveMonoBehaviour.StartCoroutine(
                PlayTrail(
                    ShootSystem.transform.position,
                    hit.point,
                    hit
                )
            );
        }
        else
        {
            ActiveMonoBehaviour.StartCoroutine(
                PlayTrail(
                    ShootSystem.transform.position,
                    ShootSystem.transform.position + (shootDirection * TrailConfig.MissDistance),
                    new RaycastHit()
                )
            );
        }
    }

    private void ProjectileShoot()
    {
        Bullet bullet = BulletPool.Get();
        bullet.gameObject.SetActive(true);
        bullet.OnCollision += HandleBulletCollision;
        bullet.transform.position = ShootSystem.transform.position;
        bullet.Spawn(ShootSystem.transform.forward * ShootConfig.BulletSpawnForce);

        TrailRenderer trail = TrailPool.Get();
        if (trail != null)
        {
            trail.transform.SetParent(bullet.transform, false);
            trail.transform.localPosition = Vector3.zero;
            trail.emitting = true;
            trail.gameObject.SetActive(true);
        }
    }

    public bool CanReload()
    {
        return AmmoConfig.CanReload();
    }

    public void StartReloading()
    {
        AudioConfig.PlayReloadClip(ShootingAudioSource);
        ActiveMonoBehaviour.StartCoroutine(AmmoConfig.Reload());
    }

    public void Tick(bool WantsToShoot)
    {
        /*
        Model.transform.localRotation = Quaternion.Lerp(
            Model.transform.loaclRotation,
            Quaternion.Euler(SpawnRotation),
            Time.deltaTime * ShootConfig.RecoilRecoverySpeed
        )*/

        if(WantsToShoot)
        {
            LastFrameWantedToShoot = true;
            TryToShoot();
        }
        if(!WantsToShoot && LastFrameWantedToShoot)
        {
            StopShootingTime = Time.time;
            LastFrameWantedToShoot = false;
        }
    }

    private IEnumerator PlayTrail (Vector3 StartPoint, Vector3 EndPoint, RaycastHit Hit)
    {
        TrailRenderer instance = TrailPool.Get();
        instance.gameObject.SetActive(true);
        instance.transform.position = StartPoint;
        yield return null;

        instance.emitting = true;

        float distance = Vector3.Distance(StartPoint, EndPoint);
        float remainingDistance = distance;
        while(remainingDistance > 0)
        {
            instance.transform.position = Vector3.Lerp(
                StartPoint,
                EndPoint,
                Mathf.Clamp01(1 - (remainingDistance / distance))
            );
            remainingDistance -= TrailConfig.SimulationSpeed * Time.deltaTime;

            yield return null;
        }

        instance.transform.position = EndPoint;

        if (Hit.collider != null)
        {
            HandleBulletImpact(EndPoint, Hit.normal, Hit.collider);    
        }

        yield return new WaitForSeconds(TrailConfig.Duration);
        yield return null;
        instance.emitting = false;
        instance.gameObject.SetActive(false);
        TrailPool.Release(instance);
    }

    private void HandleBulletCollision(Bullet Bullet, Collision Collision)
    {
        TrailRenderer trail = Bullet.GetComponentInChildren<TrailRenderer>();
        if(trail != null)
        {
            trail.transform.SetParent(null, true);
            ActiveMonoBehaviour.StartCoroutine(DelayedDisableTrail(trail));
        }

        //Bullet.gameObject.SetActive(false);
        //BulletPool.Release(Bullet);

        if(Collision !=  null)
        {
            ContactPoint contactPoint = Collision.GetContact(0);

            HandleBulletImpact(
                contactPoint.point,
                contactPoint.normal,
                contactPoint.otherCollider
            );
        }
    }

    private void HandleBulletImpact(Vector3 HitLocation, Vector3 HitNormal, Collider HitCollider)
    {
        SurfaceManager.Instance.HandleImpact(
            HitCollider.gameObject,
            HitLocation,
            HitNormal,
            ImpactType,
            0
        );
        if(HitCollider.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(DamageConfig.GetDamage());
        }
    }

    private IEnumerator DelayedDisableTrail(TrailRenderer Trail)
    {
        yield return new WaitForSeconds(TrailConfig.Duration);
        yield return null;
        Trail.emitting = false;
        Trail.gameObject.SetActive(false);
        TrailPool.Release(Trail);
    }

    private TrailRenderer CreateTrail()
    {
        GameObject instance = new GameObject("Bullet Trail");
        TrailRenderer trail = instance.AddComponent<TrailRenderer>();
        trail.colorGradient = TrailConfig.Color;
        trail.material = TrailConfig.Material;
        trail.widthCurve = TrailConfig.WidthCurve;
        trail.time = TrailConfig.Duration;
        trail.minVertexDistance = TrailConfig.MinVertexDistance;
        
        trail.emitting = false;
        trail.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        return trail;
    }

    public object Clone()
    {
        GunScriptableObject config = CreateInstance<GunScriptableObject>();

        config.ImpactType = ImpactType;
        config.Type = Type;
        config.Name = Name;
        config.name = name;
        config.DamageConfig = DamageConfig.Clone() as DamageConfigScriptableObject;
        config.ShootConfig = ShootConfig.Clone() as ShootConfigScriptableObject;
        config.AmmoConfig = AmmoConfig.Clone() as AmmoConfigScriptableObject;
        config.TrailConfig = TrailConfig.Clone() as TrailConfigScriptableObject;
        config.AudioConfig = AudioConfig.Clone() as AudioConfigScriptableObject;
            
        config.ModelPrefab = ModelPrefab;
        config.SpwanPoint = SpwanPoint;
        config.SpawnRotation = SpawnRotation;

        return config;
    }

    private Bullet CreateBullet()
    {
        return Instantiate(ShootConfig.BulletPrefab);
    }
}
