using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    private void Update()
    {
        GunSelector.ActiveGun.Tick(
            Application.isFocused && Input.GetMouseButtonDown(0) && GunSelector.ActiveGun != null
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
}
