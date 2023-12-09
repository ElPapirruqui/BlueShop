using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteraction : BaseInteraction
{
    [SerializeField] private GameObject shopMenu;
    public override void RunInteraction()
    {
        base.RunInteraction();
        ToggleShopMenu(true);
    }

    public override void StopInteraction()
    {
        base.StopInteraction();
        ToggleShopMenu(false);
    }

    public void ToggleShopMenu(bool enabled)
    {
        if (!shopMenu)
        {
            Debug.LogError("No shopMenu found");
            return;
        }

        shopMenu.SetActive(enabled);
    }
}
