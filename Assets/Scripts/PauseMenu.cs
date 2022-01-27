using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private static bool isPaused = false;
    public GameObject pauseMenuUI;
    public static bool Paused { get { return isPaused; } set { isPaused = value; } }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                resume();
            else
                pause();
        }
    }

    public void resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void quit()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
}
