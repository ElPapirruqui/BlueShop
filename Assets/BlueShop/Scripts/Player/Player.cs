using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerCollisions playerCollisions;
    [SerializeField] private PlayerInteractor playerInteractor;    

    private void Start()
    {
        if (!playerController || !playerCollisions)
        {
            Debug.LogError("No playerController or playerCollisions found");
            return;
        }
        playerController.OnInteractAction += PlayerController_OnInteractAction;
        playerCollisions.OnTriggerChange += PlayerCollisions_OnTriggerChange;
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if(!playerController || !playerMovement)
        {
            Debug.LogError("No playerController or playerMovement found");
            return;
        }

        Vector2 newDirection = playerController.GetMoveInput();
        playerMovement.Move(newDirection);
    }

    private void PlayerController_OnInteractAction(object sender, System.EventArgs e)
    {
        if (!playerInteractor)
        {
            Debug.LogError("No playerInteractor found");
            return;
        }
        playerInteractor.Interact();
    }

    private void PlayerCollisions_OnTriggerChange(object sender, PlayerCollisions.OnTriggerChangeEventArgs e)
    {
        if (!playerInteractor)
        {
            Debug.LogError("No playerInteractor found");
            return;
        }
        playerInteractor.SetInteractor(e.collider.gameObject, e.enabled);
    }
}