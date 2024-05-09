using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController : MonoBehaviour
{
    public float activeTime = 3.0f;
    public float inactiveTime = 1.0f;
    private float _timeCounter = 0.0f;

    private LineRenderer _lineRenderer;
    private BoxCollider _boxCollider;

    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>(); 
        _boxCollider = GetComponentInChildren<BoxCollider>();
    }

    void Update()
    {
        _timeCounter += Time.deltaTime;
        if (_lineRenderer.enabled) {
            if (_timeCounter > activeTime) {
                _lineRenderer.enabled = false;
                _boxCollider.enabled = false;
                _timeCounter = 0.0f;
            }
        } else {
            if (_timeCounter > inactiveTime) {
                _lineRenderer.enabled = true;
                _boxCollider.enabled = true;
                _timeCounter = 0.0f;
            }
        }
    }
}
