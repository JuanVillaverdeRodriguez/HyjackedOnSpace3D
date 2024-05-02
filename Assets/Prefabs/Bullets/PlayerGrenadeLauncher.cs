using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class PlayerGrenadeLauncher : MonoBehaviour {
    public GameObject bulletObject;
    public float shootingForce;
    public int amountOfBulletsToPool;
    public GameObject bulletSpawnPoint;
    private ObjectPool _objectPool;
    void Awake() {
        _objectPool = gameObject.AddComponent<ObjectPool>();
        _objectPool.setPoolObject(bulletObject, amountOfBulletsToPool);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.G)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
            Vector3 rayDirection = ray.direction;

            shoot(rayDirection);
        }
    }
    void shoot(Vector3 direction) {
        GameObject bullet = _objectPool.getPooledObject();
        if (bullet != null) {
            bullet.transform.position = bulletSpawnPoint.transform.position;
            bullet.transform.rotation = bulletSpawnPoint.transform.rotation;
            bullet.SetActive(true);

            bullet.transform.forward = bulletSpawnPoint.transform.TransformDirection(Vector3.forward);

            bullet.GetComponent<Rigidbody>().AddRelativeForce(direction, ForceMode.Impulse);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.transform.TransformDirection(Vector3.forward * shootingForce);

        }
    }
}