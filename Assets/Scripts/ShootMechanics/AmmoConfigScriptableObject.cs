using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ammo Config", menuName = "Guns/Ammo Config", order = 3)]
public class AmmoConfigScriptableObject : ScriptableObject, System.ICloneable
{
    public int MaxAmmo = 120;
    public int ClipSize = 30;

    public int CurrentAmmo = 120;
    public int CurrentClipAmmo = 30;
    private float ReloadSpeed = 1f;

    public IEnumerator Reload()
    {
        yield return new WaitForSeconds(ReloadSpeed);
        int maxReloadAmount = Mathf.Min(ClipSize, CurrentAmmo);
        int availableBulletsInCurrentClip = ClipSize - CurrentClipAmmo;
        int reloadAmount = Mathf.Min(maxReloadAmount, availableBulletsInCurrentClip);

        CurrentClipAmmo = CurrentClipAmmo + reloadAmount;
        CurrentAmmo -= reloadAmount;
    }

    public bool CanReload()
    {
        return CurrentClipAmmo < ClipSize && CurrentAmmo > 0;
    }

    public void AddAmmo(int Amount)
    {
        if (CurrentAmmo + Amount > MaxAmmo)
        {
            CurrentAmmo = MaxAmmo;
        }
        else
        {
            CurrentAmmo += Amount;
        }
    }

    public object Clone()
    {
        AmmoConfigScriptableObject config = CreateInstance<AmmoConfigScriptableObject>();

        Utilities.CopyValues(this, config);

        return config;
    }
}
