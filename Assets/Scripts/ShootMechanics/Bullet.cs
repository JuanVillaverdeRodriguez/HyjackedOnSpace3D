using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethod
{

}
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private Rigidbody Rigidbody;
    [SerializeField]
    public Vector3 SpawnLocation
    {
        get; private set;
    }
    [SerializeField]
    private float DelayedDisableTime = 10f;
    public delegate void CollisionEvent(Bullet Bullet, Collision Collision);
    public event CollisionEvent OnCollision;

    //Juan
    public float damage = 3f;
    public float speed = 10f;
    private float destroyTimer = 5f;
    
    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }
    
    public void Spawn(Vector3 SpawnForce)
    {
        SpawnLocation = transform.position;
        transform.forward = SpawnForce.normalized;
        Rigidbody.AddForce(SpawnForce);
        StartCoroutine(DelayedDisable(DelayedDisableTime));
    }

    private IEnumerator DelayedDisable(float Time)
    {
        yield return new WaitForSeconds(Time);
        OnCollisionEnter(null);
    }

    
    private void OnCollisionEnter(Collision Collision)
    {
        OnCollision?.Invoke(this, Collision);
    }

    private void OnDisable()
    {
        Debug.Log("DISABLE");
        // Reset everything
        StopAllCoroutines();
        Rigidbody.velocity = Vector3.zero;
        Rigidbody.angularVelocity = Vector3.zero;
        OnCollision = null;
    }

    // Juan
    void OnEnable() {
        destroyTimer = 5f;
    }

    // Juan
    void Update()
    {
        destroyTimer -= Time.deltaTime;
        if (destroyTimer <= 0) {
            destroyTimer = 1000f;
            //gameObject.SetActive(false);
        }
        
    }


}
