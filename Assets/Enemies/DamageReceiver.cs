using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    // Start is called before the first frame update

    public float health = 100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0f) {
            Destroy(gameObject);
        }
        
    }

    public void Hit(float damage) {
        health -= damage;
    }
}
