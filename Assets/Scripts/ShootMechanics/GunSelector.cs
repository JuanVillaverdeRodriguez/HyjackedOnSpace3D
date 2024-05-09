using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class GunSelector : MonoBehaviour
{
    [SerializeField]
    private GunType Gun;
    [SerializeField]
    private Transform GunParent;
    [SerializeField]
    private List<GunScriptableObject> Guns;
    [SerializeField]
    //private PlayerIK InverseKinematics;

    [Space]
    [Header("Runtime Filled")]
    public GunScriptableObject ActiveGun;

    private void Start()
    {
        GunScriptableObject gun = Guns.Find(gun => gun.Type == Gun);

        if(gun == null)
        {
            Debug.LogError($"No GunScriptableOBject found for GunType: {gun}");
            return;
        }

        SetupGun(gun);
    }

    private void SetupGun(GunScriptableObject Gun)
    {
        ActiveGun = Gun.Clone() as GunScriptableObject;
        ActiveGun.Spawn(GunParent, this);
    }

    private void DespawnGun()
    {
        ActiveGun.Despawn();
        Destroy(ActiveGun);
    }
    public void SwapGun(GunType gun)
    {
        if (gun != Gun)
        {
            Gun = gun;
            GunScriptableObject new_gun = Guns.Find(gun => gun.Type == Gun);
            
            DespawnGun();
            SetupGun(new_gun);
        }
    }

    private void UpdateCrosshair()
    {

    }
}
