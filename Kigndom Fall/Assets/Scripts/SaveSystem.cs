using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static string SaveNewGame(GameData pd)
    {
        string saveName = pd.saveTime + "";

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + saveName + ".bin";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, pd);
        stream.Close();

        return saveName;
    }

    public static GameData LoadGame(string saveName)
    {
        string path = Application.persistentDataPath + "/" + saveName + ".bin";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData gd = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return gd;
        }
        else
        {
            Debug.LogError("Arquivo não encontrado em " + path);
            return null;
        }
    }

}
