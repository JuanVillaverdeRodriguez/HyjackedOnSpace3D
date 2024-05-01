using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shoot Config", menuName =  "Guns/Shoot Configuration", order = 2)]
public class ShootConfigScriptableObject : ScriptableObject
{
    public bool IsHitscan = true;
    public Bullet BulletPrefab;
    public float BulletSpawnForce = 1000;
    
    public LayerMask HitMask;
    public Vector3 Spread = new Vector3(0.1f,0.1f,0.1f);
    public float FireRate = 0.25f;
}
