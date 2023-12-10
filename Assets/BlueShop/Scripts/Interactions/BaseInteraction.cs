using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInteraction : MonoBehaviour
{
    public string interactionName;
    public virtual void RunInteraction()
    {
        return;
    }

    public virtual void StopInteraction()
    {
        return;
    }
}
