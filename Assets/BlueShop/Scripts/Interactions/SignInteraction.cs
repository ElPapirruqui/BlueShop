using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignInteraction : BaseInteraction
{
    [SerializeField] private string message;
    [SerializeField] private InteractUI popupUI;
    public override void RunInteraction()
    {
        base.RunInteraction();
        popupUI.UpdateUI(message, transform, 0.0f);
        popupUI.ToggleUI(true);
    }

    public override void StopInteraction()
    {
        base.StopInteraction();
        popupUI.ToggleUI(false);
    }

    
}
