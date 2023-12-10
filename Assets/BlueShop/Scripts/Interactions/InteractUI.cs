using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameUI;
    public void UpdateUI(string newName, Transform parent, float offset)
    {
        nameUI.SetText(newName);
        transform.SetParent(parent);
        transform.localPosition = new Vector2(0, offset);
    }

    public void ToggleUI(bool enabled)
    {
        gameObject.SetActive(enabled);
    }
}
