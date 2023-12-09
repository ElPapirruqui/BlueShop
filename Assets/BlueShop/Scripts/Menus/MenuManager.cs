using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    [SerializeField] public ShopInventory shopUI;
    [SerializeField] public PlayerInventory playerUI;
    private void Start()
    {
        shopUI.shopGrid.OnTransaction += CurrentShopGrid_OnTransaction;
    }

    private void CurrentShopGrid_OnTransaction(object sender, GridShop.OnTransactionEventArgs e)
    {
        int gold = e.item.itemData.price;
        gold = e.enabled ? gold * -1 : gold;
        GameManager.Instance.player.UpdateGold(gold);
    }

    public void ToggleShopUI(bool enabled)
    {
        ToggleMenu(shopUI.gameObject, enabled);
    }

    public void TogglePlayerUI(bool enabled)
    {
        ToggleMenu(shopUI.gameObject, enabled);
    }

    private void ToggleMenu(GameObject menu, bool enabled)
    {
        if (enabled)
        {
            menu.SetActive(true);
            gameObject.SetActive(true);
        }
        else
        {
            shopUI.gameObject.SetActive(false);
            shopUI.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
        
    }
}
