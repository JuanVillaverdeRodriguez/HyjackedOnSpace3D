using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    private float destroyTimer = 3f;
    void Update()
    {
        destroyTimer -= Time.deltaTime;
        if (destroyTimer <= 0) {
            Destroy(gameObject);
        }
    }
}
