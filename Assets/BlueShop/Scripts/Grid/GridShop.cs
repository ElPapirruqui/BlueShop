using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridShop : Grid
{
    public override void OnItemSelected(DraggableItem item)
    {
        Debug.Log("Item Selected in SHOP");
    }

    public override void OnItemDeselected(DraggableItem item)
    {
        Debug.Log("Item Deselected in SHOP");
    }
}
