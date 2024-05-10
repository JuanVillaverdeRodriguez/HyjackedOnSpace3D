using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour
{
    private float explodeTimer = 5f;
    private Collider collider;

    void Start()
    {
        gameObject.GetComponent<ParticleSystem>().Play();
    }

    void Update()
    {
        explodeTimer -= Time.deltaTime;
        if (explodeTimer <= 0) {
            collider = Instantiate(collider);
            collider.transform.SetParent(this.gameObject, false);
            collider.transform.localPosition = this.gameObject.transform.position;
            Destroy(gameObject);
        }
    }

}
