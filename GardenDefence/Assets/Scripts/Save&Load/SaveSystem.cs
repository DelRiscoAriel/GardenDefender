using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    public static void SavePlayer(GameManager player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        //Get a path to a data director on your operationg system that won't change
        string path = Application.persistentDataPath + "/player.fun";
        //Create a file stream
        FileStream stream = new FileStream(path, FileMode.Create);
        //Pass in our player data class
        GameData data = new GameData(player);

        //insert into the file
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.fun";
        //check to see if file exists
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            //Open file
            FileStream stream = new FileStream(path, FileMode.Open);
            //casting the Player data to store in the data object
            GameData data = formatter.Deserialize(stream) as GameData;
            //Close file
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("save file not found in " + path);
            return null;
        }
    }
}