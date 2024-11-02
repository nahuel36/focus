using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Newtonsoft.Json;
using System.IO;
public class MenuItemGameData : MonoBehaviour
{
   



    // Start is called before the first frame update
    [MenuItem("Lab36/Erase All Progress")]
    static void EraseAll()
    {
        PlayerPrefs.DeleteAll();
        GameData.RemoveAll();
        UserDataManager.DeleteKey("data");
    }

    static void AddCoins(int amount)
    {
        if (Application.isPlaying)
            FindFirstObjectByType<GameManager>().AddCoin(amount);
        else
            FindFirstObjectByType<GameData>().AddCoins(amount);
    }

    [MenuItem("Lab36/Get 5 coins")]
    static void Add5Coins()
    {
        AddCoins(5);
    }

    [MenuItem("Lab36/Get 10 coins")]
    static void Add10Coins()
    {
        AddCoins(10);
    }

    [MenuItem("Lab36/Set Galaxy Achievement")]
    static void SetGalaxy()
    {
        FindFirstObjectByType<GameData>().SetAchievement(AchievementsManager.achievement.galaxy);
    }

    [MenuItem("Lab36/Get Galaxy Achievement")]
    static void GetGalaxy()
    {
        Debug.Log(FindFirstObjectByType<GameData>().GetAchievement(AchievementsManager.achievement.galaxy));
    }
}
