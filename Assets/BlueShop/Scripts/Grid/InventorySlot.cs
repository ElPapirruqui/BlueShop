using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Grid parentGrid;
    public DraggableItem item;
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
        AssingItem(draggableItem);
    }

    public void AssingItem(DraggableItem newItem)
    {
        if (newItem.isSelected)
        {
            if (item)
            {
                if (item.CanSwitch() && newItem.CanSwitch())
                {
                    SetNewParents(newItem);
                    item.SwitchSlot(newItem.slot);
                    ReasignItem(newItem);
                }
            }
            else
            {
                SetNewParents(newItem);
                ReasignItem(newItem, true);
            }
        }
    }

    private void SetNewParents(DraggableItem newItem)
    {
        newItem.SetNewParent(transform);
        newItem.SetNewGrid(parentGrid);
    }

    private void ReasignItem(DraggableItem newItem, bool clearOld = false)
    {
        if (clearOld)
        {
            newItem.slot.item = null;
        }
        newItem.slot = this;
        item = newItem;
    }
}
