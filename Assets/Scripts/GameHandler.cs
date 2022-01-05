using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private string mainSceneName = "MainMenu";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mainMenu()
    {
        loadScene(mainSceneName);
    }

    private void loadScene(string name)
    {
        SceneHandler.loadScene(name);
    }

    public void LoadSceneTrigger(SceneLoadTrigger trigger)
    {
        loadScene(mainSceneName);
    }

}
