using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{

    public event EventHandler<OnTriggerChangeEventArgs> OnTriggerChange;
    public class OnTriggerChangeEventArgs : EventArgs
    {
        public Collider2D collider;
        public bool enabled;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTriggerChange?.Invoke(this, new OnTriggerChangeEventArgs {
            collider = collision,
            enabled = true
        });;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnTriggerChange?.Invoke(this, new OnTriggerChangeEventArgs {
            collider = collision,
            enabled = false
        });
    }
}
