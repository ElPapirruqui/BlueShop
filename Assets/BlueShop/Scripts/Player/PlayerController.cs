using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Interact.performed += Interact_performed;
        playerInputActions.Player.Menu.performed += Menu_performed;
    }

    private void Menu_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        bool enabled = GameManager.Instance.menuManager.playerUI.gameObject.activeInHierarchy;
        GameManager.Instance.menuManager.TogglePlayerUI(!enabled);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMoveInput()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        return inputVector;
    }
}
