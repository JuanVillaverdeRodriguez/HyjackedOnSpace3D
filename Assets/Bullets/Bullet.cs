using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Bullet(Vector3 origin) {
        transform.position = origin;
    }

    public float damage;
    public float speed;
    void Start()
    {
        Debug.Log("SE CREO LA BALA");
    }

    void Update()
    {
        
    }
}
