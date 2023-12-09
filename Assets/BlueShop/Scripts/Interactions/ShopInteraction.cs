using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteraction : BaseInteraction
{
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
        if (enabled)
        {
            GameManager.Instance.menuManager.ToggleShopUI(true);
            GameManager.Instance.menuManager.TogglePlayerUI(true);
        }
        else
        {
            GameManager.Instance.menuManager.ToggleShopUI(false);
        }
        
    }
}
