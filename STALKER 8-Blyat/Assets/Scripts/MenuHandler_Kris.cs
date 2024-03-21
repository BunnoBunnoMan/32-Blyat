using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler_Kris : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject quitScreen;
    public static bool paused = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
        paused = true;
    }
    public void Resume()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        quitScreen.SetActive(false);
        paused = false;
    }
    public void ToTitle(string sceneName)
    {
        //Debug.Log("Start");
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }
    public void QuitQuery()
    {
        quitScreen.SetActive(true);
    }
    public void CancelQuery()
    {
        quitScreen.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
    
}
