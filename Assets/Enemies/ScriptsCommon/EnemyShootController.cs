using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyShootController : MonoBehaviour
{
    public Bullet bulletObject;
    private ObjectPool<Bullet> _objectPool;
    public GameObject bulletSpawnPoint;
    public float shootingForce;
    public int amountOfBulletsToPool;
    [SerializeField]
    public int damage;

    void Awake() {
        _objectPool = new ObjectPool<Bullet>(CreateBullet, defaultCapacity: amountOfBulletsToPool, maxSize: amountOfBulletsToPool);
        //_objectPool.setPoolObject(bulletObject, amountOfBulletsToPool);
    }
    public void shoot(Vector3 playerPosition) {
        bulletSpawnPoint.transform.LookAt(playerPosition);
        
        Vector3 directionToPlayer = playerPosition - bulletSpawnPoint.transform.position;
        
        Bullet bullet = _objectPool.Get();
        if (bullet != null) {
            bullet.transform.position = bulletSpawnPoint.transform.position;
            bullet.transform.rotation = Quaternion.identity;
            bullet.OnCollision += HandleImpact;
            bullet.gameObject.SetActive(true);
            bullet.transform.forward = bulletSpawnPoint.transform.TransformDirection(Vector3.forward);
            
            bullet.Spawn(bullet.transform.forward *shootingForce);

            bullet.GetComponent<Rigidbody>().AddRelativeForce(directionToPlayer, ForceMode.Impulse);
            //bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.transform.TransformDirection(Vector3.forward * shootingForce);
        }
    }

    private Bullet CreateBullet()
    {
        return Instantiate(bulletObject);
    }

    private void HandleImpact(Bullet bullet, Collision Collision)
    {
        if(Collision !=  null)
        {

            ContactPoint contactPoint = Collision.GetContact(0);

            if(contactPoint.otherCollider.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(damage);
            }
            bullet.gameObject.SetActive(false);

            _objectPool.Release(bullet);

        }
    }
    private void OnDestroy() {
        _objectPool.Dispose();
    }

}