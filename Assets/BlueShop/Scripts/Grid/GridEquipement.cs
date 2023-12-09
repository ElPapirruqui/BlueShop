using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridEquipement : Grid
{
    public override void OnItemSelected(DraggableItem item)
    {
        Debug.Log("Item Selected in EQUIPEMENT");
    }

    public override void OnItemDeselected(DraggableItem item)
    {
        Debug.Log("Item Deselected in EQUIPEMENT");
    }
}
