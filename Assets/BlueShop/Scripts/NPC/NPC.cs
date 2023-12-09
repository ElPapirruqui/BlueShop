using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    public void Interact(){
        Debug.Log($"Interacting with {gameObject.name}");
    }

    public void ToggleInteraction(bool enabled)
    {
        if (enabled)
        {
            Debug.Log("interact YES");
        }
        else
        {
            Debug.Log("interact NO");
        }
    }
}
