using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyHealth Health;
    public EnemyDeath Death;
    
    private void Start()
    {
        Health.OnTakeDamage += HandleDamage;
        Health.OnDeath += Die;
    }

    private void Die(Vector3 Position)
    {
        transform.parent.gameObject.tag = "Untagged";
        Destroy(gameObject);
    }

    // Funcion para implementar animacion de daños
    private void HandleDamage(int damage)
    {
        Debug.Log("DAÑO RECIBIDO");
    }
}
