using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupInteraction : BaseInteraction
{
    [SerializeField] private ItemData itemData;
    public override void RunInteraction()
    {
        base.RunInteraction();
        GameManager.Instance.player.PickupItem(itemData);
        Destroy(gameObject);
    }
}
