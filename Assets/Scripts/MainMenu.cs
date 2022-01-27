using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string gameSceneName = "Game";
    [SerializeField] Inventory inventory;
    [SerializeField] UnityEngine.UI.Slider masterVolumeSlider;
    [SerializeField] UnityEngine.UI.Slider musicVolumeSlider;
    [SerializeField] UnityEngine.UI.Slider fxVolumeSlider;

    private void Start()
    {
        masterVolumeSlider.value = AudioHandler.Singleton.MasterVolume;
    }
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
