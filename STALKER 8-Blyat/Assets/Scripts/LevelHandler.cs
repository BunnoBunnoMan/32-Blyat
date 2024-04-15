using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public string sceneName;
    private MenuHandler_Kris menuHandler = new MenuHandler_Kris();
    public void OnTriggerEnter2D(Collider2D collider)
    {
        menuHandler.ToTitle(sceneName);
    }
}
