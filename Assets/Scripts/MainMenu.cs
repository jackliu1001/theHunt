using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string gameSceneName = "Game";
    [SerializeField] private Inventory inventory;
    public void NewGameButton()
    {
        inventory.ClearInventory();
        gameLoad();
    }
    public void gameLoad()
    {
        SceneHandler.loadScene("Game");
    }

    public void quitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
