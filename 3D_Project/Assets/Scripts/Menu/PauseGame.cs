using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject gameUI;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
            gameUI.SetActive(false);
        }
    }
}
