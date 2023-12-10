using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public ShopInventory shopUI;
    public PlayerInventory playerUI;
    public ItemDescUI itemDescUI;

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
        ToggleMenu(playerUI.gameObject, enabled);
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
            if (menu.activeInHierarchy) { 
                shopUI.gameObject.SetActive(false);
                shopUI.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }

}
