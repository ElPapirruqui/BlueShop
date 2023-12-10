using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameUI;

    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void UpdateUI(string newName, Transform parent, float offset)
    {
        nameUI.SetText(newName);
        transform.position = new Vector2(parent.position.x, parent.position.y + offset);
    }

    public void ToggleUI(bool enabled)
    {
        gameObject.SetActive(enabled);
    }
}
