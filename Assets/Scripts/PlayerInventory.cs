using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public void Heal(int heal_num)
    {
        Debug.Log("Curado: " + heal_num);
    }

    public void GetAmmo(int ammo_num)
    {
        Debug.Log("Ammo: " + ammo_num);
    }

    public void GetGrenades(int grenades_num)
    {
        Debug.Log("Grenades: " + grenades_num);
    }
}
