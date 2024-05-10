using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour
{
    private float explodeTimer = 5f;
    private new Collider collider;
    public int explosionDamage = 20;

    void Start()
    {
        gameObject.GetComponent<ParticleSystem>().Play();
        collider = gameObject.GetComponent<SphereCollider>();
        collider.enabled = false;
    }

    void Update()
    {
        explodeTimer -= Time.deltaTime;
        if (explodeTimer > 0 && explodeTimer < 1.5f)
        {
            collider.enabled = true;
        }
        if (explodeTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contactPoint = collision.GetContact(0);

        Debug.Log("EXPLOSION");
        if(contactPoint.otherCollider.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(explosionDamage);
        }
    }

}
