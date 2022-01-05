using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneHandler
{  
    public static void loadScene(string stringName)
    {
        SceneManager.LoadScene(stringName);
    }
}
