using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameData : MonoBehaviour
{
    // Start is called before the first frame update
    [MenuItem("PlayerPrefs/Erase All")]
    static void EraseAll()
    {
        PlayerPrefs.DeleteAll();
    }

    static void AddCoins(int amount)
    {
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + amount);
    }

    [MenuItem("PlayerPrefs/Get 5 coins")]
    static void Add5Coins()
    {
        AddCoins(5);
    }

    [MenuItem("PlayerPrefs/Get 10 coins")]
    static void Add10Coins()
    {
        AddCoins(10);
    }
}
