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
        GameManager.Instance.menuManager.ToggleShopUI(enabled);
        GameManager.Instance.menuManager.TogglePlayerUI(enabled);
    }
}
