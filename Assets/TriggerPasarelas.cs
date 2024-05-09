using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPasarelas : MonoBehaviour
{
    public List<GameObject> pasarelasList;

    private void OnTriggerEnter(Collider other) {
        foreach (GameObject catwalk in pasarelasList) {
            Rigidbody rigidbody = catwalk.GetComponent<Rigidbody>();
            rigidbody.useGravity = true;
            rigidbody.isKinematic = false;
        }
    }

}
