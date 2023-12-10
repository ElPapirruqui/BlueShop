using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignInteraction : BaseInteraction
{
    [SerializeField] private string message;
    public override void RunInteraction()
    {
        base.RunInteraction();
        Debug.Log(message);
    }

    public override void StopInteraction()
    {
        base.StopInteraction();
    }

    
}
