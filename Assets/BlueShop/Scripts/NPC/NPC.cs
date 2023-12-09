using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] private BaseInteraction interaction;
    [SerializeField] private GameObject interactionUI;

    public BaseInteraction GetInteraction()
    {
        return interaction;
    }

    public GameObject GetInteractionUI()
    {
        return interactionUI;
    }

    public void Interact(){
        var interact = GetInteraction();
        if (interact == null)
        {
            Debug.LogError("No interaction found");
            return;
        }

        interact.RunInteraction();
    }

    public void ToggleInteraction(bool enabled)
    {
        var interactUI = GetInteractionUI();
        if (interactUI == null)
        {
            Debug.LogError("No interaction UI found");
            return;
        }

        interactUI.SetActive(enabled);
    }
}
