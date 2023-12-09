using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    [SerializeField] private Grid parentGrid;
    [SerializeField] private Image itemIcon;
    private Transform oldParent;
    private Transform selectedItem;

    public void OnBeginDrag(PointerEventData eventData)
    {
        selectedItem = transform;
        itemIcon.raycastTarget = false;
        oldParent = selectedItem.parent;
        selectedItem.SetParent(MenuManager.Instance.transform);
        selectedItem.SetAsLastSibling();

        parentGrid.OnItemSelected(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!selectedItem) return;
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        parentGrid.OnItemDeselected(this);
        ResetItem();   
    }

    private void ResetItem()
    {
        itemIcon.raycastTarget = true;
        if (!selectedItem) return;
        selectedItem.SetParent(oldParent);
        selectedItem.localPosition = Vector3.zero;
        selectedItem = null;
    }

    public void SetNewGrid(Grid newParentGrid)
    {
        parentGrid = newParentGrid;
    }

    public void SetNewParent(Transform newParent)
    {
        oldParent = newParent;
    }

    private void OnEnable()
    {
        SetNewParent(oldParent);
        ResetItem();
    }
}
