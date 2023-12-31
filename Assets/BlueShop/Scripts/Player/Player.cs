using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerCollisions playerCollisions;
    [SerializeField] private PlayerInteractor playerInteractor;
    [SerializeField] private SpriteRenderer playerHat;

    private int gold = 100;
    private void Start()
    {
        playerController = GameManager.Instance.playerController;
        if (!playerController || !playerCollisions)
        {
            Debug.LogError("No playerController or playerCollisions found");
            return;
        }
        playerController.OnInteractAction += PlayerController_OnInteractAction;
        playerCollisions.OnTriggerChange += PlayerCollisions_OnTriggerChange;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    public int GetGold()
    {
        return gold;
    }

    public void PickupItem(ItemData itemData)
    {
        GameManager.Instance.menuManager.playerUI.AddItem(itemData);
    }

    public void UpdateGold(int gold)
    {
        this.gold += gold;
        GameManager.Instance.menuManager.playerUI.UpdateGoldText(this.gold);
    }

    public void EquipItem(ItemData item, bool equip = true)
    {
        if (equip)
        {
            playerHat.sprite = item.icon;
        }
        else {
            playerHat.sprite = null;
        }
        
    }

    public bool IsWalking()
    {
        return playerMovement.IsMoving();
    }

    private void MovePlayer()
    {
        if(!playerController || !playerMovement)
        {
            Debug.LogError("No playerController or playerMovement found");
            return;
        }

        Vector2 newDirection = playerController.GetMoveInput();
        playerMovement.Move(newDirection);
    }

    private void PlayerController_OnInteractAction(object sender, System.EventArgs e)
    {
        if (!playerInteractor)
        {
            Debug.LogError("No playerInteractor found");
            return;
        }
        playerInteractor.Interact();
    }

    private void PlayerCollisions_OnTriggerChange(object sender, PlayerCollisions.OnTriggerChangeEventArgs e)
    {
        if (!playerInteractor)
        {
            Debug.LogError("No playerInteractor found");
            return;
        }
        playerInteractor.SetInteractor(e.collider.gameObject, e.enabled);
    }
}
