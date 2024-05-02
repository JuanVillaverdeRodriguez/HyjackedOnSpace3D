using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethod
{

}
public class Bullet : MonoBehaviour
{
    public float damage = 3f;
    public float speed = 10f;
    private float destroyTimer = 5f;
    
    void Start()
    {
        //GetComponent<Rigidbody>().AddRelativeForce(transform.forward * speed);
    }

    void OnEnable() {
        destroyTimer = 5f;
    }

    void Update()
    {
        destroyTimer -= Time.deltaTime;
        if (destroyTimer <= 0) {
            destroyTimer = 5f;
            gameObject.SetActive(false);
        }
        
    }


}
