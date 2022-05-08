using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class Manger 
{
    public static string directory = "/SaveData/";
    public static string fileName = "Data.txt";

    public static void Save(SaveObject so)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        string json = JsonUtility.ToJson(so);
            File.WriteAllText(dir + fileName, json);
    }

    public static SaveObject Load()
    {
        string fullpath = Application.persistentDataPath + directory + fileName;
        SaveObject so = new SaveObject();


        if (File.Exists(fullpath))
        {
            string json = File.ReadAllText(fullpath);
            so = JsonUtility.FromJson<SaveObject>(json);
        }
        else
        {
            Debug.Log("End my suffering");
        }

        return so;
    } 
}
