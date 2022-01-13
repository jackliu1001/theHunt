using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string gameSceneName = "Game";



    public void gameLoad()
    {
        loadScene(gameSceneName);
    }

    private void loadScene(string name)
    {
        SceneHandler.loadScene(name);
    }
}
