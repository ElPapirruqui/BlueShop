using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridEquipement : Grid
{
    public event EventHandler<OnEquipEventArgs> OnEquip;
    public class OnEquipEventArgs : EventArgs
    {
        public ItemData itemData;
        public bool enabled;
    }
    public override void OnItemSelected(DraggableItem item)
    {
        OnEquip?.Invoke(this, new OnEquipEventArgs
        {
            itemData = item.itemData,
            enabled = false
        });
        base.OnItemSelected(item);
    }

    public override void OnItemDeselected(DraggableItem item)
    {
        OnEquip?.Invoke(this, new OnEquipEventArgs
        {
            itemData = item.itemData,
            enabled = true
        });
        base.OnItemDeselected(item);
    }
}
