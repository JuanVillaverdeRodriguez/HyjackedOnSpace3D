using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;

    public TextMeshProUGUI _canInteractText; 
    private float timePressed = 0.0f;


    private void Start() {
        //_canInteractText.GetComponentInChildren<TextMeshPro>();
        _canInteractText.enabled = false;

    }

    private void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position,
            _interactionPointRadius, _colliders,_interactableMask);

        if(_numFound > 0){
            _canInteractText.enabled = true;
            var interactable = _colliders[0].GetComponent<Interactable>();

            if (interactable != null && Input.GetButton("Interact"))
            {
                timePressed += Time.deltaTime;

                Debug.Log("E pulsada");

                interactable.Interact(this);
                _canInteractText.enabled = false;

            } else {
                if (timePressed > 0.0f) {
                    timePressed = 0.0f;
                    interactable.Interact(this);
                }
            }
        }
        else {
            _canInteractText.enabled = false;
        }
    
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }

    internal float getTimePressed()
    {
        return timePressed;
    }

}
