using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShootController : MonoBehaviour
{
    public GameObject bulletObject;
    private ObjectPool _objectPool;
    public GameObject bulletSpawnPoint;
    public float shootingForce;
    public int amountOfBulletsToPool;

    void Awake() {
        _objectPool = gameObject.AddComponent<ObjectPool>();
        _objectPool.setPoolObject(bulletObject, amountOfBulletsToPool);
    }
    public void shoot(Vector3 playerPosition) {
        bulletSpawnPoint.transform.LookAt(playerPosition);
        
        Vector3 directionToPlayer = playerPosition - bulletSpawnPoint.transform.position;
        
        GameObject bullet = _objectPool.getPooledObject();
        if (bullet != null) {
            bullet.transform.position = bulletSpawnPoint.transform.position;
            bullet.transform.rotation = Quaternion.identity;
            bullet.SetActive(true);

            bullet.transform.forward = bulletSpawnPoint.transform.TransformDirection(Vector3.forward);

            bullet.GetComponent<Rigidbody>().AddRelativeForce(directionToPlayer, ForceMode.Impulse);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.transform.TransformDirection(Vector3.forward * shootingForce);
        }
    }

}