using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridShop : Grid
{
    public event EventHandler<OnTransactionEventArgs> OnTransaction;
    public event EventHandler OnCantBuy;
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
        int playerGold = GameManager.Instance.player.GetGold();
        bool canDrag = playerGold >= item.itemData.price;

        if (!canDrag)
        {
            OnCantBuy?.Invoke(this, EventArgs.Empty);
            return false;
        }

        return true;
    }
}
