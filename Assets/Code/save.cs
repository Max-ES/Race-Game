using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class save
{

    public static void SaveBestTime(float bestTime)
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file = File.Create(destination);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, bestTime);
        file.Close();
    }

    public static float GetBestTime()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return 9999999;
        }

        BinaryFormatter bf = new BinaryFormatter();
        float bestTime =(float) bf.Deserialize(file);
        file.Close();

        Debug.Log(bestTime);
        return bestTime;
    }
}