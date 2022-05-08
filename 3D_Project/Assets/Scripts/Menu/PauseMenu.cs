using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject gameUI;

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        gameUI.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Well our game was better off without you playing it.");
        Application.Quit();
    }
    void OnApplicationPause()
    {
        Debug.Log("End my suffering");
    }
    void OnApplicationQuit()
    {
    Debug.Log("Let me out!!!!!!!!!!!!");
    }
}
