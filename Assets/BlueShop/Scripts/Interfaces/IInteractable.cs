using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void Interact();
    public void ToggleInteraction(bool enabled);
    public GameObject GetInteractionUI();
    public BaseInteraction GetInteraction();
}
