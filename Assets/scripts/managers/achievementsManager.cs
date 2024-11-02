using UnityEngine;
using System.Collections;
using System;

public class AchievementsManager : MonoBehaviour
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
            achievements[i] = GameData.Instance.GetAchievement((achievement)i);
        }

        EventsExecute.Instance.data.SetLeave("show particles", setGalaxyAchievement);
        EventsExecute.Instance.data.SetLeave("show spin", setSpinAchievement);
        EventsExecute.Instance.data.SetLeave("show smoke", setSmokeAchievement);
    }

    public void setAchievement(achievement achiv)
    {
        if (achievements[(int)achiv] == false)
        { 
            achievements[(int)achiv] = true;
            GameData.Instance.SetAchievement(achiv);
            message.achivUnlocked();
        }
    }

    public bool getAchievement(achievement achiv)
    {
        return achievements[(int)achiv];
    }

    void setGalaxyAchievement() { 
        setAchievement(AchievementsManager.achievement.galaxy);
    }

    void setSpinAchievement()
    {
        setAchievement(AchievementsManager.achievement.spin);
    }

    void setSmokeAchievement()
    {
        setAchievement(AchievementsManager.achievement.smoke);
    }
}
