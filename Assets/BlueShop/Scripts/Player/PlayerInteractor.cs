using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public IInteractable interactor;
    public void SetInteractor(GameObject newInteractor, bool enabled)
    {
        if (newInteractor.TryGetComponent<IInteractable>(out IInteractable interactalbeObject))
        {
            if (enabled)
            {
                interactor = interactalbeObject;
                interactor.ToggleInteraction(true);
            }
            else
            {
                if(interactor == interactalbeObject)
                {
                    interactor.ToggleInteraction(false);
                    interactor = null;
                }                
            }
        }
    }

    public void Interact()
    {
        if (interactor == null) return;
        interactor.Interact();
    }
}
