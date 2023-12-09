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
    private bool isSelected;

    private void Awake()
    {
        itemIcon.sprite = itemData.icon;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!parentGrid.CheckCanDrag(this)) {
            isSelected = false;
            return;
        }

        isSelected = true;
        itemIcon.raycastTarget = false;
        oldParent = transform.parent;
        transform.SetParent(MenuManager.Instance.transform);
        transform.SetAsLastSibling();

        parentGrid.OnItemSelected(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isSelected) return;
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isSelected) return;
        parentGrid.OnItemDeselected(this);
        ResetItem();   
    }

    private void ResetItem()
    {
        itemIcon.raycastTarget = true;
        if (!isSelected) return;
        transform.SetParent(oldParent);
        transform.localPosition = Vector3.zero;
        isSelected = false;
    }

    public void SetNewGrid(Grid newParentGrid)
    {
        if (!isSelected) return;
        parentGrid = newParentGrid;
    }

    public void SetNewParent(Transform newParent)
    {
        if (!isSelected) return;
        oldParent = newParent;
    }

    private void OnDisable()
    {
        if (isSelected)
        {
            parentGrid.OnItemDeselected(this);
        }
    }

    private void OnEnable()
    {
        SetNewParent(oldParent);
        ResetItem();
    }
}
