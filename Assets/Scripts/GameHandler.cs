using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private string mainSceneName = "MainMenu";
    [SerializeField] private SceneTriggers[] sceneTriggers;
    [System.Serializable] public struct SceneTriggers
    {
        public string sceneName;
        public int targetTriggerIndex;
        public SceneLoadTrigger trigger;
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
        foreach (SceneTriggers sceneTrigger in sceneTriggers)
        {
            Debug.Log(sceneTrigger.trigger);
            if (sceneTrigger.trigger == trigger)
            {
                loadScene(sceneTrigger.sceneName);
                triggerFound = true;
                SceneLoadHandler.TargetTrigger = sceneTrigger.targetTriggerIndex;
            }
        }
        //if not in list, load main menu
        if (!triggerFound) loadScene(mainSceneName);
    }

    public SceneLoadTrigger GetSceneLoadTrigger(int index)
    {
        if (index >= sceneTriggers.Length || index < 0)
        {
            Debug.LogWarning("Scene trigger index invalid");
            return sceneTriggers[0].trigger;
        }
        else
            return sceneTriggers[index].trigger;
    }
}
