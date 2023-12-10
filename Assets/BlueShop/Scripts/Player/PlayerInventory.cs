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
        GameManager.Instance.player.EquipItem(e.itemData, e.enabled);
    }

    public void UpdateGoldText(int gold)
    {
        goldText.SetText(gold.ToString());
    }

    public void AddItem(ItemData newItem)
    {
        playerGrid.AddItem(newItem);
    }
    private void OnEnable()
    {
        int gold = GameManager.Instance.player.GetGold();
        UpdateGoldText(gold);
    }
}
