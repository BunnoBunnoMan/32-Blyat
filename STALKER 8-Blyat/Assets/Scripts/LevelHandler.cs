using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public string sceneName;
    public MenuHandler_Kris menuHandler;
    public void OnTriggerEnter2D()
    {
        menuHandler.ToTitle(sceneName);
    }
}
