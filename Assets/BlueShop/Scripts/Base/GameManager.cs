using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    public Player player;
    public MenuManager menuManager;
    public AudioManager audioManager;
    public DraggableItem itemPrefab;
    public static GameManager Instance { get; private set; }
    private bool isGamePaused;
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
        playerController.OnPauseAction += PlayerController_OnPauseAction;
        playerController.OnMenuPerformed += PlayerController_OnMenuPerformed;
    }

    private void PlayerController_OnMenuPerformed(object sender, System.EventArgs e)
    {
        bool enabled = menuManager.playerUI.gameObject.activeInHierarchy;
        menuManager.TogglePlayerUI(!enabled);
    }

    private void PlayerController_OnPauseAction(object sender, System.EventArgs e)
    {
        TogglePause();
    }

    public void TogglePause()
    {
        isGamePaused = !isGamePaused;
        if (isGamePaused)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }


}
