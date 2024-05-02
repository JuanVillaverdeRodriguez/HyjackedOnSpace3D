using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPistol : MonoBehaviour
{
    public float damage;

    public GameObject bulletSpawnPoint;

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            shoot();
        }
    }
    void shoot() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            HealthController healthController = hit.collider.GetComponent<HealthController>();
            if (healthController != null) {
                if (hit.collider.gameObject.CompareTag("Enemy")) {
                    healthController.hit(damage);
                }

                if (hit.collider.gameObject.CompareTag("Destructible")) {
                    healthController.hit(damage);
                }
            }
        }
    }

}
