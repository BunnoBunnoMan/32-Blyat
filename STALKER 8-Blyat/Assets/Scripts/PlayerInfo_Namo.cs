using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo_Namo : MonoBehaviour
{
    void Start()
    {
        LoadPlayer();
    }
    public void SavePlayer()
    {
        SaveSystem_Namo.Save(this);
    }
    public void LoadPlayer()
    {
        Vector3 position;
        PlayerSaver_Namo data = SaveSystem_Namo.Load();
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}
