using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveDamageCreator : MonoBehaviour
{

    public int DamagePerSecond = 25;
    public float coolDown = 1.0f;

    void Update() {
        coolDown -= Time.deltaTime;
    }
    private void OnTriggerStay(Collider collider)
    {

        if (coolDown <= 0.0f) {
            coolDown = 1.0f;
            if(collider.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(1000);
            }
        }
        
    }
}
