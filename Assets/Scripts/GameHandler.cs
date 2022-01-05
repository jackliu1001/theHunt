using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private string mainSceneName = "MainMenu";
    [SerializeField] private SceneTriggers[] sceneTriggers;

    [System.Serializable]
    public struct SceneTriggers 
    {
        public string sceneName;
        public SceneLoadTrigger trigger;
        
    }
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
        Debug.Log(trigger);
        bool triggerFound = false;
        foreach(SceneTriggers sceneTrigger in sceneTriggers)
        {
            Debug.Log(sceneTrigger.trigger);
            if (sceneTrigger.trigger == trigger)
            {
                loadScene(sceneTrigger.sceneName);
                triggerFound = true;
            }
        }
        //if not in list, load main menu
        if(!triggerFound) loadScene(mainSceneName);
    }

}
