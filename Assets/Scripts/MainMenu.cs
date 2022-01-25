using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string gameSceneName = "Game";
    [SerializeField] Inventory inventory;

    public void gameLoad()
    {
        SceneHandler.loadScene("Game");
        Time.timeScale = 1;
    }

    public void newGame()
    {
        inventory.ClearInventory();
        gameLoad();
    }

    public void quitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
