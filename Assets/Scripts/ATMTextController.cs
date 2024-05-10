using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ATMTextController : MonoBehaviour
{

    public Camera cameraTarget;
    public TextMeshProUGUI text;
    public float rotationSpeed = 1.0f;
    

    void Start() {
        GetComponent<RectTransform>();
    }
    void Update()
    {
        text.enabled = cameraIsCloseEnought();
        if (text.enabled) {
            rotateTowardsCamera();
        }
    }
    bool cameraIsCloseEnought() {
        Debug.Log(Vector3.Distance(cameraTarget.transform.position, transform.position));
        if (Vector3.Distance(cameraTarget.transform.position, transform.position) <= 25.0f)
            return true;
        return false;
    }

    void rotateTowardsCamera() {
        Vector3 targetDirection = transform.position - cameraTarget.transform.position;

        float singleStep = rotationSpeed * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
