using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
    public static event appEvent startPressed;
    public static event appEvent loose;
    public static event appEvent continue_pressed;
    public static event appEvent addedCoin;

    public appState actualState;

    public float actualTime;
    public float bestTime;
    public float startingTime;

    public UnityAdsExample Ad;

    public int startPresedTimes;
    public bool first_time = true;

    public int Coins;
    public int NextCoin = 0;

    public achievementsManager AchievementsMan;
    [SerializeField] EventsExecute events;
    public void showBanner() {
        if (PlayerPrefs.GetInt("no_ads", 0) == 0)
            Debug.Log("banner");
                }

    public void showAd() {
        Debug.Log("Ad");
    }
   

    


    void Start()
    {
        events.data.OnStartPressedEvents["gamemanager start"].OnEnter += PressStart;

        first_time = true;
        actualState = appState.MENU;
        LocalizationManager.Initialize();
        Invoke("showBanner", 5);

        bestTime = PlayerPrefs.GetFloat("best");
        startPresedTimes = PlayerPrefs.GetInt("PresedStartTimes");
        Coins = PlayerPrefs.GetInt("Coins");
    }


    public void DelayedStart(float delay)
    {
        events.PressStart();
    }

    private void PressStart()
    {
        if (actualState == appState.MENU || actualState == appState.RESULTS)
        {
            actualState = appState.STARTING;
            startingTime = 0;

            if (startPressed != null)
                startPressed();

            startPresedTimes++;
            PlayerPrefs.SetInt("PresedStartTimes", startPresedTimes);
        }
    }

    public void Continue()
    {
        actualState = appState.PLAYING;

        if (continue_pressed != null)
            continue_pressed();
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
                    AddCoin(1);
                }
                else if (NextCoin == 60)
                {
                    AchievementsMan.setAchievement(achievementsManager.achievement.seconds2);
                    AddCoin(2);
                }
                else if (NextCoin == 120)
                { 
                    AchievementsMan.setAchievement(achievementsManager.achievement.seconds3);
                    AddCoin(4);
                }
                else if(NextCoin == 300)
                { 
                    AchievementsMan.setAchievement(achievementsManager.achievement.seconds4);
                    AddCoin(4);
                }
                else
                    AddCoin(4);
            }
        }
        else if (actualState == appState.STARTING) 
		{
            if (first_time && startingTime < 4)
            {
                startingTime += Time.deltaTime;
            }
            else if (Input.GetMouseButtonDown(0))
            {
                first_time = false;
                actualState = appState.PLAYING;
                actualTime = 0;
                NextCoin = 30;
                if (ballMoveStarted != null)
                    ballMoveStarted();
            }
        }
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

        events.EndGame();
    }

    public void RestartGame()
    {
        DelayedStart(0.5f);
    }


    public void GoToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
