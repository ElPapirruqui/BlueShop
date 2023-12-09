using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private int slotsCount;
    [SerializeField] private List<InventorySlot> slotsList;

    public void BuildGrid()
    {
        DestroyGrid();
        for (int i = 0; i < slotsCount; i++)
        {
            var newCell = Instantiate(slotPrefab);
            newCell.name = $"slot{i + 1}";
            var cellTransform = newCell.transform;
            cellTransform.SetParent(transform);
            cellTransform.localScale = new Vector3(1, 1, 1);
            InventorySlot inventorySlot = newCell.GetComponent<InventorySlot>();
            if (!inventorySlot) return;

            slotsList.Add(inventorySlot);
            inventorySlot.parentGrid = this;
        }
    }

    public void DestroyGrid()
    {
        slotsList.Clear();
        var myTransform = transform;
        for (var i = myTransform.childCount - 1; i >= 0; i--)
        {
            var child = myTransform.GetChild(i).gameObject;
            DestroyImmediate(child);
        }
    }

    public virtual bool CheckCanDrag(DraggableItem item)
    {
        return true;
    }

    public virtual void OnItemSelected(DraggableItem item)
    {
        
    }

    public virtual void OnItemDeselected(DraggableItem item)
    {
        
    }
}
