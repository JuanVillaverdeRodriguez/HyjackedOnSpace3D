using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float damage;
    public float speed;

    public float radius;

    //public ParticleSystem explosionParticles;
    public GameObject explosionObject;
    private Vector3 rayDirection = Vector3.zero;

    private float explodeTimer = 5f;

    void Start()
    {
        //explosionParticles.Play();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        rayDirection = ray.direction;
        rayDirection.Normalize();
        rayDirection.Set(0, rayDirection.y * speed, speed);
        GetComponent<Rigidbody>().AddRelativeForce(rayDirection);
    }

    void Update()
    {
        explodeTimer -= Time.deltaTime;
        if (explodeTimer <= 0) {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

            foreach (Collider collider in colliders) {
                DamageReceiver scriptComp = collider.GetComponent<DamageReceiver>();

                if (scriptComp != null) {
                    scriptComp.Hit(damage);
                }
            }
            Instantiate(explosionObject, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}
