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
            Vector3 offset = transform.TransformDirection(new Vector3(0,0.5f,3));

            Instantiate(bulletObject, origin + offset, rotation);
            Debug.Log("SE PRESIONO EL BOTON");


        }
        
    }
}