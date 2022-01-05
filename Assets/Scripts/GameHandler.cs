using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private string mainMenuSceneName = "MainMenu";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void MainMenuButton()
    {
        loadScene(mainMenuSceneName);
    }

    private void loadScene(string sceneName)
    {
        SceneHandler.LoadScene(sceneName);
        
    }

    public void LoadSceneTrigger(SceneLoadTrigger trigger)
    {
        loadScene(mainMenuSceneName);
    }
}
