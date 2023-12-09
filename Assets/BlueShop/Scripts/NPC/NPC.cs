using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject interactionUI;

    public GameObject GetInteractionUI()
    {
        return interactionUI;
    }

    public void Interact(){
        Debug.Log($"Interacting with {gameObject.name}");
    }

    public void ToggleInteraction(bool enabled)
    {
        GetInteractionUI().SetActive(enabled);
    }
}
