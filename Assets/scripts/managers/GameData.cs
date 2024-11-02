using UnityEngine;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System;
public class GameData : MonoBehaviour
{
    class Data
    {
        public int coins = 0;
        public int best = 0;
        public int pressedStartTimes = 0;
        public Dictionary<AchievementsManager.achievement, bool> achievements;
    }

    private static GameData instance;

    public static GameData Instance{get{ return instance; }}

    private const bool usePlayerPrefs = true;

    Data data;

    private const string filename = "gameData.bin";
    static string DataPath()
    {
        var path = Application.persistentDataPath;
#if UNITY_WEBGL && !UNITY_EDITOR
         path = "/idbfs/FocusSaveData";
          if (!Directory.Exists(path)) {
             Directory.CreateDirectory(path);
         }
#endif
        var result = Path.Combine(path, filename);
        return result;
    }

    public void CheckDataExists()
    {
        if (data == null)
            LoadDataFromDisk();
    }

    public void AddCoins(int cuantity) {
        CheckDataExists();
        data.coins += cuantity;
        SaveDataToDisk();
    }

    public int GetPressedStartTimes()
    {
        CheckDataExists();
        return data.pressedStartTimes;
    }

    public int GetBest()
    {
        CheckDataExists();
        return data.best;
    }

    public int GetCoins()
    {
        CheckDataExists();
        return data.coins;
    }

    public bool GetAchievement(AchievementsManager.achievement achi)
    {
        CheckDataExists();
        return data.achievements[achi];
    }

    public void SetAchievement(AchievementsManager.achievement achi)
    {
        CheckDataExists();
        data.achievements[achi] = true;
        SaveDataToDisk();
    }

    public void SetPressedStartTimes(int times)
    {
        CheckDataExists();
        data.pressedStartTimes = times;
        SaveDataToDisk();
    }

    public void ReplaceBest(int best) {
        CheckDataExists();
        data.best = best;
        SaveDataToDisk();
    }
    void SaveDataToDisk()
    {
        string json = JsonConvert.SerializeObject(data);

        SimplerAES encryptor = new SimplerAES();
        string jsonEnc = encryptor.Encrypt(json);

        if (!usePlayerPrefs)
        {
            string itemsBinFilePath = DataPath();
            StreamWriter stream = File.CreateText(itemsBinFilePath);
            stream.Write(jsonEnc);
            stream.Close();
        }
        else
        {
            PlayerPrefs.SetString("data", jsonEnc);
        }
    }


    void LoadDataFromDisk()
    {


        if (!usePlayerPrefs && File.Exists(DataPath()))
        {
            StreamReader stream = File.OpenText(DataPath());
            string jsonEnc = stream.ReadToEnd();
            SimplerAES decryptor = new SimplerAES();
            string json = decryptor.Decrypt(jsonEnc);
            stream.Close();
            data = JsonConvert.DeserializeObject<Data>(json);
        }
        else if (usePlayerPrefs && PlayerPrefs.HasKey("data"))
        {
            string jsonEnc = PlayerPrefs.GetString("data");
            SimplerAES decryptor = new SimplerAES();
            string json = decryptor.Decrypt(jsonEnc);
            data = JsonConvert.DeserializeObject<Data>(json);
        }
        else 
        {
            data = new Data();
            data.achievements = new Dictionary<AchievementsManager.achievement, bool>();
            for (int i = 0; i < Enum.GetValues(typeof(AchievementsManager.achievement)).Length; i++)
            {
                data.achievements.Add((AchievementsManager.achievement)i, false);
            }
            SaveDataToDisk();
        }
    }

    private void Awake()
    {
        instance = this;
        LoadDataFromDisk();
    }

    public static void RemoveAll() {
        if (File.Exists(DataPath()))
        {
            File.Delete(DataPath());
        }
    }
}
