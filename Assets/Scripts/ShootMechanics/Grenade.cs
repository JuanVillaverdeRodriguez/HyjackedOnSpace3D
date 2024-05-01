using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float damage;

    public float radius;

    //public ParticleSystem explosionParticles;
    public GameObject explosionObject;

    private float explodeTimer = 5f;

    void OnEnable()
    {
        Debug.Log("DESPERTE");
        explodeTimer = 5f;
    }

    void Update()
    {
        explodeTimer -= Time.deltaTime;
        if (explodeTimer <= 0) {
            explode();
            gameObject.SetActive(false);
        }
    }

    void explode() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        
        foreach (Collider collider in colliders) {
            //HealthController healthController = collider.GetComponent<HealthController>();

            /*
            if (healthController != null) {
                if (collider.gameObject.CompareTag("Player")) {
                    // No hagas daño
                }

                /*if (collider.gameObject.CompareTag("Enemy")) {
                    healthController.hit(damage);
                    
                }

                if (collider.gameObject.CompareTag("Destructible")) {
                    //healthController.hit(damage);

                }
            }
            */
        }
        Instantiate(explosionObject, transform.position, transform.rotation);
    }

}
