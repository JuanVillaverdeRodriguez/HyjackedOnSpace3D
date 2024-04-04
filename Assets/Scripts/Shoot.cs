using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float shootingCooldown = 3f;
    public GameObject bulletObject;


    void Start()
    {
        Debug.Log("SE INICIALIZA EL SCRIPT");
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)) {
            transform.GetPositionAndRotation(out Vector3 origin, out Quaternion rotation);
            Instantiate(bulletObject, origin, rotation);
            Debug.Log("SE PRESIONO EL BOTON");


        }
        
    }
}