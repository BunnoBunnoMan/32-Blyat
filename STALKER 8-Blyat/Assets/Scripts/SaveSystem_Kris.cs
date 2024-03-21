using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem_Kris
{
    public static void Save(PlayerInfo_Kris player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.save";
        FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);


        PlayerSaver_Kris data = new PlayerSaver_Kris(player);
        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static PlayerSaver_Kris Load()
    {
        string path = Application.persistentDataPath + "/player.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);
            PlayerSaver_Kris data = formatter.Deserialize(fileStream) as PlayerSaver_Kris;
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
