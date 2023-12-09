using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlayer : Grid
{
    public override void OnItemSelected(DraggableItem item)
    {
        Debug.Log("Item Selected in PLAYER");
    }

    public override void OnItemDeselected(DraggableItem item)
    {
        Debug.Log("Item Deselected in PLAYER");
    }
}
