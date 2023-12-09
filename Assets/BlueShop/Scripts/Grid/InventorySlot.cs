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

        if (draggableItem.isSelected) { 
            if (item) {
                if (item.CanSwitch() && draggableItem.CanSwitch()) { 
                    SetNewParents(draggableItem);
                    item.SwitchSlot(draggableItem.slot);
                    ReasignItem(draggableItem);
                }
            }
            else
            {
                SetNewParents(draggableItem);
                ReasignItem(draggableItem, true);
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
