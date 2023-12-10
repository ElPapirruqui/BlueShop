using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemDescUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameUI;
    [SerializeField] private TextMeshProUGUI priceUI;
    // Start is called before the first frame update
    public void Show(Vector2 newPosition, string name, string price)
    {
        nameUI.SetText(name);
        priceUI.SetText(price);
        gameObject.SetActive(true);
        transform.position = newPosition;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
