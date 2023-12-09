using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GridShop currentShopGrid;
    public static MenuManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        currentShopGrid.OnTransaction += CurrentShopGrid_OnTransaction;
    }

    private void CurrentShopGrid_OnTransaction(object sender, GridShop.OnTransactionEventArgs e)
    {
        int gold = e.item.itemData.price;
        gold = e.enabled ? gold * -1 : gold;
        player.UpdateGold(gold);
    }

    public int GetPlayerGold()
    {
        return player.GetGold();
    }
}
