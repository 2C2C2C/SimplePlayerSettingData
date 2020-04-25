using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class LocalSaveManager
{
    public static void TempSave<T>(T data) where T : SaveBaseClass<T>, new()
    {
        if (data == null)
        {
            data = new T();
        }
        Dictionary<string, object> dic = data.ModelChangeToDic();
        string jsonStr = MiniJSON.Json.Serialize(dic);
        string path = string.Format("{0}/{1}.json", Application.persistentDataPath, data.GetFileName());
        StreamWriter writeFile = null;
        Debug.Log(string.Format("setting path {0}", path));
        Debug.Log(string.Format("setting content {0}", jsonStr));

        try
        {
            if (File.Exists(path))
            {
                // backup last setting
                string bkPath = string.Format("{0}.bk", path);
                if (File.Exists(bkPath))
                {
                    string lastSetting = File.ReadAllText(path, System.Text.UTF8Encoding.Default);
                    writeFile = new StreamWriter(File.Open(bkPath, FileMode.Truncate));
                    writeFile.WriteLine(lastSetting);
                    writeFile.Dispose();
                    writeFile.Close();
                }
                else
                {
                    System.IO.File.Copy(path, bkPath, true);
                }

                writeFile = new StreamWriter(File.Open(path, FileMode.Truncate));
                writeFile.WriteLine(jsonStr);
                writeFile.Dispose();
                writeFile.Close();
            }
            else
            {

                StreamWriter sw = new StreamWriter(File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite), System.Text.UTF8Encoding.Default);
                sw.WriteLine(jsonStr);
                sw.Dispose();
                sw.Close();
            }
        }
        catch (UnauthorizedAccessException uae)
        {
            Debug.LogError(string.Format("Sorry you don't have the permission to save player setting \n {0}", uae.ToString()));
            return;
        }

    }

    public static T TempLoad<T>() where T : SaveBaseClass<T>, new()
    {
        T data = new T();

        Debug.Log(string.Format("To Get {0}", Application.persistentDataPath));
        string path = string.Format("{0}/{1}.json", Application.persistentDataPath, data.GetFileName());
        string jsonStr = null;

        try
        {
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(File.Open(path, FileMode.Open, FileAccess.Read), System.Text.UTF8Encoding.Default);
                jsonStr = sr.ReadToEnd();
                sr.Dispose();
                sr.Close();
            }
            else
            {
                Debug.Log("setting file has not found, return a default");
                return default;
            }
        }
        catch (UnauthorizedAccessException uae)
        {
            Debug.LogError(string.Format("Sorry you don't have the permission to load player setting \n {0}", uae.ToString()));
            return default;
        }

        Dictionary<string, object> dict = MiniJSON.Json.Deserialize(jsonStr) as Dictionary<string, object>;
        data.DicChangeToModel(dict);

        Debug.Log(string.Format("load data : \n {0}", data.ToString()));
        return data;
    }

    public static void TempDelete<T>() where T : SaveBaseClass<T>, new()
    {
        T data = new T();
        Debug.Log(string.Format("To Get {0}", Application.persistentDataPath));
        string path = string.Format("{0}/{1}.json", Application.persistentDataPath, data.GetFileName());

        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log(string.Format("delete setting file at {0}", path));
        }
        else
            Debug.Log("no  setting file to delete");

    }
}
