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


}
