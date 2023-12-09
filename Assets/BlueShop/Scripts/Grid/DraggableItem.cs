using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    [SerializeField] private Grid parentGrid;
    [SerializeField] private Image itemIcon;
    public ItemData itemData;
    private Transform oldParent;
    private Transform selectedItem;

    private void Awake()
    {
        itemIcon.sprite = itemData.icon;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!parentGrid.CheckCanDrag(this)) {
            selectedItem = null;
            return;
        } 

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
        if (!selectedItem) return;
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
        if (!selectedItem) return;
        parentGrid = newParentGrid;
    }

    public void SetNewParent(Transform newParent)
    {
        if (!selectedItem) return;
        oldParent = newParent;
    }

    private void OnEnable()
    {
        SetNewParent(oldParent);
        ResetItem();
    }
}
