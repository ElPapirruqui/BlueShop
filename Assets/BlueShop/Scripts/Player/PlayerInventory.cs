using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private Grid playerGrid;
    [SerializeField] private Grid equipement;
    [SerializeField] private TextMeshProUGUI goldText;
    public int gold = 100;

    public void UpdateGold(int gold)
    {
        this.gold += gold;
        UpdateGoldText();
    }

    private void UpdateGoldText()
    {
        goldText.SetText(gold.ToString());
    }
    private void OnEnable()
    {
        UpdateGoldText();
    }
}
