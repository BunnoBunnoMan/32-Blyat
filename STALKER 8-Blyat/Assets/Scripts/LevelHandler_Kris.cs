using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public string sceneName;
    public MenuHandler_Kris menuHandler;
    public GameObject thisObject;
    public GameObject enemy;
    private Vector2 eSpawnPos = new Vector2(7.5f, 0);
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && thisObject.name != "Button") menuHandler.ToTitle(sceneName);
        else if (collision.gameObject.name == "Player" &&thisObject.name == "Button") Instantiate(enemy, eSpawnPos, Quaternion.identity);
    }
}
