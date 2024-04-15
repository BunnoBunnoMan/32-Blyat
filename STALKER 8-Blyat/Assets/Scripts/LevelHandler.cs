using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public string sceneName;
    private MenuHandler_Kris menuHandler = new();
    public void OnTriggerEnter2D()
    {
        menuHandler.ToTitle(sceneName);
    }
}
