using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string gameSceneName = "Game";

    public void GameLoadButton()
    {
        loadScene(gameSceneName);
    }

    private void loadScene(string sceneName)
    {
        SceneHandler.LoadScene(sceneName);
        
    }
}
