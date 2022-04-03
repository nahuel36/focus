using UnityEngine;
using System.Collections;
using System;

public class achievementsManager : MonoBehaviour
{
    public enum achievement
    { 
        seconds1,
        seconds2,
        seconds3,
        seconds4,
        ponged1,
        ponged2,
        ponged3,
        galaxy,
        smoke,
        spin,
    }

    public bool[] achievements;
    public MessagesManager message;

// Use this for initialization
    void Start ()
    {
        achievements = new bool[Enum.GetNames(typeof(achievement)).Length];

        for (int i = 0; i < Enum.GetNames(typeof(achievement)).Length; i++)
        { 
            achievements[i] = PlayerPrefs.GetInt(Enum.GetName(typeof(achievement),i)) == 1;
        }
    }

    public void setAchievement(achievement achiv)
    {
        if (achievements[(int)achiv] == false)
        { 
            achievements[(int)achiv] = true;
            PlayerPrefs.SetInt(Enum.GetName(typeof(achievement), achiv), 1);
            message.achivUnlocked();
        }
    }

    public bool getAchievement(achievement achiv)
    {
        return achievements[(int)achiv];
    }

}
