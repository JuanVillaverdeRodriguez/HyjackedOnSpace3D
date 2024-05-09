using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constantRotation : MonoBehaviour
{
    private Vector3 eje = Vector3.up;
    public float rotationVelocity = 20f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationVelocity*eje*Time.deltaTime);
    }
}