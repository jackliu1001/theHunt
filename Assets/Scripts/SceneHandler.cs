using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneHandler : MonoBehaviour
{  
    public static void loadScene(string stringName)
    {
        SceneManager.LoadScene(stringName);
    }
}
