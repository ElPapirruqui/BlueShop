using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    public event EventHandler OnPauseAction;
    public event EventHandler OnMenuPerformed;
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Interact.performed += Interact_performed;
        playerInputActions.Player.Menu.performed += Menu_performed;
        playerInputActions.Player.Pause.performed += Pause_performed;
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }

    private void Menu_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnMenuPerformed?.Invoke(this, EventArgs.Empty); 
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
