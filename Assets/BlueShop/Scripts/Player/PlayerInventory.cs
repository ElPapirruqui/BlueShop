using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private Grid playerGrid;
    [SerializeField] private GridEquipement equipement;
    [SerializeField] private TextMeshProUGUI goldText;
    public int gold = 100;

    private void Start()
    {
        equipement.OnEquip += Equipement_OnEquip;
    }

    private void Equipement_OnEquip(object sender, GridEquipement.OnEquipEventArgs e)
    {
        MenuManager.Instance.player.EquipItem(e.itemData, e.enabled);
    }

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
