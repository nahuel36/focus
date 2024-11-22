using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Rendering.Universal;

public enum appState
{
    MENU,
    STARTING,
    PLAYING,
    RESULTS,
}

public class GameManager : MonoBehaviour {

    public delegate void appEvent();
    public static event appEvent ballMoveStartedEvent;
    public static event appEvent looseEvent;
    public static event appEvent addedCoinEvent;

    public appState actualState;

    public float actualTime;
    public float startingTime;

    public int startPresedTimes;
    public bool showedSwipe = false;

    public int Coins;
    int[] CoinsRewardsTimes = { 10,20,25,30};
    int[] AchievementsTimes = { 30, 60, 120, 300 };
    private int actualCoinReward = 0;
    private int actualAchiv = 0;

    public AchievementsManager AchievementsMan;
  
    public bool debugMode = false;

    void Start()
    {
        EventsExecute.Instance.data.SetEnter("gamemanager start",PressStart);
        EventsExecute.Instance.data.SetEnter("show swipe",OnShowSwipe);
        EventsExecute.Instance.data.SetEnter("start ball move",StartingShowedSwipeAndClick);
        EventsExecute.Instance.data.SetEnter("gamemanager continue", Continue);
        EventsExecute.Instance.data.SetEnter("enable debug buttons", EnableDebugButtons);

        debugMode = false;
        showedSwipe = false;
        actualState = appState.MENU;

        startPresedTimes = GameData.Instance.GetPressedStartTimes();
        Coins = GameData.Instance.GetCoins();
    }

    private void EnableDebugButtons()
    {
        throw new NotImplementedException();
    }

    private void OnShowSwipe()
    {
        showedSwipe = true;
    }

    private void PressStart()
    {
        if (actualState == appState.MENU || actualState == appState.RESULTS)
        {
            actualState = appState.STARTING;
            showedSwipe = false;
            debugMode = false;
            startingTime = 0;

            startPresedTimes++;
            GameData.Instance.SetPressedStartTimes(startPresedTimes);
        }
    }

    public void Continue()
    {
        actualState = appState.PLAYING;
    }

    public void AddCoin(int quantity)
    {
        Coins += quantity;
        GameData.Instance.SetCoins(quantity);
       
        if (addedCoinEvent != null)
            addedCoinEvent();
    }


    void Update()
    {
        if (actualState == appState.PLAYING)
        {
            actualTime += Time.deltaTime;   
            
            if ((actualCoinReward < CoinsRewardsTimes.Length && actualTime >= CoinsRewardsTimes[actualCoinReward])
                || (actualCoinReward >= CoinsRewardsTimes.Length && actualTime >= CoinsRewardsTimes[CoinsRewardsTimes.Length-1] + (5 * (actualCoinReward - CoinsRewardsTimes.Length + 1))))
            {
                actualCoinReward++;

                if (actualCoinReward == 1)//10
                { 
                    AddCoin(1);
                }
                else if (actualCoinReward == 2)//20
                {
                    AddCoin(2);
                }
                else if (actualCoinReward == 3)//25
                { 
                    AddCoin(2);
                }
                else if(actualCoinReward == 4)//30
                { 
                    AddCoin(3);
                }
                else
                    AddCoin(4);
            }
            if (actualAchiv < AchievementsTimes.Length && actualTime >= AchievementsTimes[actualAchiv])
            {
                actualAchiv++;
                if (actualAchiv == 1)
                {
                    AchievementsMan.setAchievement(AchievementsManager.achievement.seconds1);
                }
                else if (actualAchiv == 2)
                {
                    AchievementsMan.setAchievement(AchievementsManager.achievement.seconds2);
                }
                else if (actualAchiv == 3)
                {
                    AchievementsMan.setAchievement(AchievementsManager.achievement.seconds3);
                }
                else if (actualAchiv == 4)
                {
                    AchievementsMan.setAchievement(AchievementsManager.achievement.seconds4);
                }
            }
        }
        else if (actualState == appState.STARTING && showedSwipe && Input.GetMouseButtonDown(0)) 
		{
            EventsExecute.Instance.ExecuteConditional(FocusEventConditional.Condition.starting_showedswipe_and_clicked);
            
        }
    }

	public void StartingShowedSwipeAndClick()
    {
        actualState = appState.PLAYING;
        actualTime = 0;
        actualCoinReward = 0;
        actualAchiv = 0;
        if (ballMoveStartedEvent != null)
            ballMoveStartedEvent();
    }

    public void Loose()
    {
        actualState = appState.RESULTS;

        if (looseEvent != null)  
            looseEvent();

        EventsExecute.Instance.EndGame();
    }



    public void NextDebug()
    {
        if (debugMode)
        { }
    }

    public void PreviousDebug() 
    {
        if (debugMode)
        { }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
