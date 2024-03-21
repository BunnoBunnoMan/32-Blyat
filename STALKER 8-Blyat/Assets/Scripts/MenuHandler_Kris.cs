using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler_Kris : MonoBehaviour
{
    public Button button;

    public void Start(string sceneName)
    {
        //Debug.Log("Start");
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
