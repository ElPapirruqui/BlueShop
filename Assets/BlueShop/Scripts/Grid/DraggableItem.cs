using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] private Grid parentGrid;
    [SerializeField] private Image itemIcon;
    public ItemData itemData;
    private Transform oldParent;
    public bool isSelected;
    public InventorySlot slot;

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        if (!slot)
        {
            slot = transform.parent.GetComponent<InventorySlot>();
            slot.item = this;
        }
    }

    public void Init()
    {
        if (!itemData) return;

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
        transform.SetParent(GameManager.Instance.menuManager.transform);
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

    public bool CanSwitch()
    {
        if (!parentGrid) return true;

        return parentGrid.CheckCanDrag(this);
    }
    public void SwitchSlot(InventorySlot newSlot)
    {
        isSelected = true;
        if(parentGrid) parentGrid.OnItemSelected(this);
        slot = newSlot;
        slot.item = this;
        SetNewParent(newSlot.transform);
        SetNewGrid(newSlot.parentGrid);
        if (parentGrid) parentGrid.OnItemDeselected(this);
        ResetItem();
        isSelected = false;
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log($"mouse in: {itemData.name}");
        GameManager.Instance.menuManager.itemDescUI.Show(eventData.position, itemData.name, itemData.price.ToString());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("mouse out");
        GameManager.Instance.menuManager.itemDescUI.Hide();
    }
}
