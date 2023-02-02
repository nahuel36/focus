using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public enum appState
{
    MENU,
    STARTING,
    PLAYING,
    RESULTS,
}

public class gameManager : MonoBehaviour {

    public delegate void appEvent();
    public static event appEvent ballMoveStarted;
    public static event appEvent loose;
    public static event appEvent addedCoin;

    public appState actualState;

    public float actualTime;
    public float bestTime;
    public float startingTime;

    public int startPresedTimes;
    public bool showedSwipe = false;

    public int Coins;
    public int NextCoin = 0;

    public achievementsManager AchievementsMan;
  


    void Start()
    {
        EventsExecute.Instance.data.SetEnter("gamemanager start",PressStart);
        EventsExecute.Instance.data.SetEnter("show swipe",OnShowSwipe);
        EventsExecute.Instance.data.SetEnter("start ball move",StartingShowedSwipeAndClick);
        EventsExecute.Instance.data.SetEnter("gamemanager continue", Continue);


        showedSwipe = false;
        actualState = appState.MENU;
        LocalizationManager.Initialize();

        bestTime = PlayerPrefs.GetFloat("best");
        startPresedTimes = PlayerPrefs.GetInt("PresedStartTimes");
        Coins = PlayerPrefs.GetInt("Coins");
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
            startingTime = 0;

            startPresedTimes++;
            PlayerPrefs.SetInt("PresedStartTimes", startPresedTimes);
        }
    }

    public void Continue()
    {
        actualState = appState.PLAYING;
    }

    public void AddCoin(int quantity)
    {
        Coins += quantity;
        PlayerPrefs.SetInt("Coins", Coins);

        if (actualState == appState.PLAYING)
            NextCoin += 30;
        
        if (addedCoin != null)
            addedCoin();
    }


    void Update()
    {
        if (actualState == appState.PLAYING)
        {
            actualTime += Time.deltaTime;   
            
            if ( actualTime >= NextCoin)
            {
                if (NextCoin == 30)
                { 
                    AchievementsMan.setAchievement(achievementsManager.achievement.seconds1);
                    AddCoin(2);
                }
                else if (NextCoin == 60)
                {
                    AchievementsMan.setAchievement(achievementsManager.achievement.seconds2);
                    AddCoin(3);
                }
                else if (NextCoin == 120)
                { 
                    AchievementsMan.setAchievement(achievementsManager.achievement.seconds3);
                    AddCoin(4);
                }
                else if(NextCoin == 300)
                { 
                    AchievementsMan.setAchievement(achievementsManager.achievement.seconds4);
                    AddCoin(5);
                }
                else
                    AddCoin(4);
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
        NextCoin = 30;
        if (ballMoveStarted != null)
            ballMoveStarted();
    }

    public void Loose()
    {
        if (bestTime < actualTime)
        { 
            bestTime = actualTime;
            PlayerPrefs.SetFloat("best", actualTime);
        }

        actualState = appState.RESULTS;

        if (loose != null)  
            loose();

        EventsExecute.Instance.EndGame();
    }




    public void GoToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
