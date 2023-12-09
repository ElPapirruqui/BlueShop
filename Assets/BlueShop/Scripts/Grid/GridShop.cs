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
        base.OnItemSelected(item);
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

    public override bool CheckCanDrag(DraggableItem item)
    {
        int playerGold = MenuManager.Instance.player.GetGold();
        return playerGold >= item.itemData.price;
    }
}
