using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignInteraction : BaseInteraction
{
    [SerializeField] private string message;
    [SerializeField] private InteractUI popupUI;
    [SerializeField] private float offset = 0.0f;
    public override void RunInteraction()
    {
        base.RunInteraction();
        popupUI.UpdateUI(message, transform, offset);
        popupUI.ToggleUI(true);
    }

    public override void StopInteraction()
    {
        base.StopInteraction();
        popupUI.ToggleUI(false);
    }

    
}
