using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem_Namo
{
    public static void Save(PlayerInfo_Namo player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.save";
        FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);


        PlayerSaver_Namo data = new PlayerSaver_Namo(player);
        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static PlayerSaver_Namo Load()
    {
        string path = Application.persistentDataPath + "/player.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);
            PlayerSaver_Namo data = formatter.Deserialize(fileStream) as PlayerSaver_Namo;
            fileStream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save Not Found");
            return null;
        }
    }
}
