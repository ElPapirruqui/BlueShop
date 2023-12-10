using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItem : MonoBehaviour, IInteractable
{
    [SerializeField] private BaseInteraction interaction;
    [SerializeField] private InteractUI interactionUI;
    public BaseInteraction GetInteraction()
    {
        return interaction;
    }

    public InteractUI GetInteractionUI()
    {
        return interactionUI;
    }

    public void Interact()
    {
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

        interactUI.UpdateUI(interaction.interactionName, transform, 0.0f);
        interactUI.ToggleUI(enabled);

        var interact = GetInteraction();
        if (!enabled && interact != null)
        {
            interact.StopInteraction();
        }
    }
}
