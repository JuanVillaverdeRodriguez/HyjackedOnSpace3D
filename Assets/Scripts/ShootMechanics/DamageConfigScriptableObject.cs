using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Damage Config", menuName = "Guns/Damage Config", order = 1)]
public class DamageConfigScriptableObject : ScriptableObject, System.ICloneable
{
    public int damage;

    public int GetDamage(){
        return damage;
    }

    public object Clone()
    {
        DamageConfigScriptableObject config = CreateInstance<DamageConfigScriptableObject>();

        return config;
    }
}
