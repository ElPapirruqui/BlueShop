using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridShop : Grid
{
    public event EventHandler<OnTransactionEventArgs> OnTransaction;
    public class OnTransactionEventArgs : EventArgs
    {
        public DraggableItem item;
        public bool enabled;
    }
    public override void OnItemSelected(DraggableItem item)
    {
        Debug.Log("Item Selected in SHOP");
        OnTransaction?.Invoke(this, new OnTransactionEventArgs
        {
            item = item,
            enabled = true
        });
        base.OnItemDeselected(item);
    }

    public override void OnItemDeselected(DraggableItem item)
    {
        Debug.Log("Item Deselected in SHOP");
        OnTransaction?.Invoke(this, new OnTransactionEventArgs
        {
            item = item,
            enabled = false
        });
        base.OnItemDeselected(item);
    }
}
