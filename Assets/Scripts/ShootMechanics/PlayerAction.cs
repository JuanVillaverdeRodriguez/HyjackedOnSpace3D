using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[DisallowMultipleComponent]
public class PlayerAction : MonoBehaviour
{
    [SerializeField]
    private GunSelector GunSelector;
    [SerializeField]
    private PlayerInventory playerInventory;
    [SerializeField]
    private bool AutoReload = true;
    private bool IsReloading = false;
    public PlayerHealth health;
    public IDamageable Damageable;

    private void OnEnable()
    {
        Damageable.OnDeath += Player_OnDeath;
    }

    private void Update()
    {
        GunSelector.ActiveGun.Tick(
            Application.isFocused && Input.GetMouseButton(0) && GunSelector.ActiveGun != null
        );
        if (ShouldManualReload() || ShouldAutoReload())
        {
            GunSelector.ActiveGun.StartReloading();
            IsReloading = true;
        }
    }

    private bool ShouldManualReload()
    {
        return !IsReloading
            && Input.GetKeyUp(KeyCode.R)
            && GunSelector.ActiveGun.CanReload();
        /*return !IsReloading
            && Keyboard.current.rKey.wasReleasedThisFrame
            && GunSelector.ActiveGun.CanReload();*/
    }

    private bool ShouldAutoReload()
    {
        return !IsReloading
            && AutoReload
            && GunSelector.ActiveGun.AmmoConfig.CurrentClipAmmo == 0
            && GunSelector.ActiveGun.CanReload();

    }

    private void Player_OnDeath(Vector3 Position)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
