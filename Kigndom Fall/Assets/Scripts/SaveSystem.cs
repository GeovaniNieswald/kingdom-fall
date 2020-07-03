using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using Firebase.Database;

public static class SaveSystem
{
    public static string SaveNewGame(GameData gd)
    {
        string saveName = gd.saveTime + "";

        gd.nomeArquivo = saveName;

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + saveName + ".kifbin";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, gd);
        stream.Close();

        SalvarFirebase(gd);

        return saveName;
    }

    public static GameData LoadGame(string saveName)
    {
        string path = Application.persistentDataPath + "/" + saveName + ".kifbin";
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

    public static List<GameData> LoadGames()
    {
        Debug.Log(Application.persistentDataPath);

        BinaryFormatter formatter = new BinaryFormatter();

        List<GameData> gds = new List<GameData>();

        foreach (string file in Directory.EnumerateFiles(Application.persistentDataPath, "*.kifbin"))
        {
            FileStream stream = new FileStream(file, FileMode.Open);

            GameData gd = formatter.Deserialize(stream) as GameData;
            gds.Add(gd);

            stream.Close();
        }

        return gds;
    }

    private static void SalvarFirebase(GameData gd)
    {
        RankingEntry rankingEntry = new RankingEntry();
        rankingEntry.nome = gd.nomeJogador;
        rankingEntry.pontuacao = gd.pontuacao;
        
        string json = JsonUtility.ToJson(rankingEntry);

        FirebaseDatabase.DefaultInstance
        .GetReference("pontuacoes")
        .Child(gd.nomeArquivo)
        .SetRawJsonValueAsync(json);
    }

}
