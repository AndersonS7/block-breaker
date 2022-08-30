using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveData(int score)
    {
        BinaryFormatter binary = new BinaryFormatter();

        string path = Application.persistentDataPath + "/score.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        ScoreData data = new ScoreData(score);

        binary.Serialize(stream, data);
        stream.Close();

        Debug.Log("Dados salvos com sucesso");
    }

    public static ScoreData LoadScore()
    {
        string path = Application.persistentDataPath + "/score.txt";
        if (File.Exists(path))
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ScoreData data = binary.Deserialize(stream) as ScoreData;
            stream.Close();

            Debug.Log("Arquivo encontrado, dados carregados...");
            return data;
        }
        else
        {
            Debug.Log("Arquivo não encontrado...");
            return null;
        }
    }
}
