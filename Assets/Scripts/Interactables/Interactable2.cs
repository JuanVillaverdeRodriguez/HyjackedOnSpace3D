using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Interactable2
{
    public string InteractPrompt();

    public void Interact(Interactor2 interactor);
}
