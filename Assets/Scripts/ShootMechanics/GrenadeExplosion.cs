using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour
{
    private float explodeTimer = 5f;

    void Start()
    {
        gameObject.GetComponent<ParticleSystem>().Play();
    }

    void Update()
    {
        explodeTimer -= Time.deltaTime;
        if (explodeTimer <= 0) {
            Destroy(gameObject);
        }
    }

}
