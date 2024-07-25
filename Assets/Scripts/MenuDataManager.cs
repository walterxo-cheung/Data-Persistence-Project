using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MenuDataManager : MonoBehaviour
{
    public static MenuDataManager Instance;
    public string PlayerName;
    public string HighPlayerName;
    public int HighScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SaveGameData()
    {
        SaveData data = new SaveData();
        data.HighPlayerName = Instance.HighPlayerName;
        data.HighScore = Instance.HighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGameData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Instance.HighPlayerName = data.HighPlayerName;
            Instance.HighScore = data.HighScore;
        }
    }
}

[System.Serializable]
class SaveData
{
    public string HighPlayerName;
    public int HighScore;
}
