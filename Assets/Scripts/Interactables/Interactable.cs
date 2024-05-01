using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Interactable
{
    public string InteractPrompt{ get; }

    public void Interact(Interactor interactor);
}
