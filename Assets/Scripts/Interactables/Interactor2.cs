using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor2 : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;

    public UiInteractibles _interactibles;
    private Interactable2 interactable;

    private void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position,
            _interactionPointRadius, _colliders, _interactableMask);


        if (_numFound > 0)
        {
            interactable = _colliders[0].GetComponent<Interactable2>();

            if (interactable != null)
            {
                if (Input.GetButton("Interact"))
                {

                    interactable.Interact(this);
                }
                if (!_interactibles.activo)
                {
                    _interactibles.activarUi(interactable.InteractPrompt());
                    Debug.Log(interactable.InteractPrompt());
                }
            }

        }
        else
        {
            if (interactable != null)
            {
                interactable = null;
            }
            if (_interactibles.activo)
            {
                _interactibles.DesactivarUi();
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }

}
