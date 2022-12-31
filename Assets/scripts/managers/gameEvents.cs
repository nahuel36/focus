using UnityEngine;
using System.Collections;

public class gameEvents : MonoBehaviour {

    public delegate void gameEvent();
    //public static event gameEvent ball_newDirection_message;
    public static event gameEvent ball_hide;
    public static event gameEvent ball_show;
    public static event gameEvent pong_show;
    public static event gameEvent effects_showSpin;
    public static event gameEvent effects_hideSpin;
    public static event gameEvent effects_hideParticles;
    public static event gameEvent effects_showParticles;
    public static event gameEvent effects_hideSmoke;
    public static event gameEvent effects_showSmoke;
    public static event gameEvent border_moveDown;
    public static event gameEvent border_stopMoveDown;

    public achievementsManager achievements;
    /*
    public static event gameEvent pong_hide;
    public static event gameEvent borders_moveDown;
    public static event gameEvent borders_moveUp;
    public static event gameEvent borders_incline;
    public static event gameEvent borders_decline;
    */
    private float timeSinceMove;
    private bool counter_activated;
    private int actual_event;
    private float randomSecs;
    private bool moved_down;
    public float lastEventTime;

    void Start()
    {
        gameManager.ballMoveStarted += ballStarted;
        gameManager.startPressed += ballShow;
        gameManager.loose += loose;
        gameManager.continue_pressed += continue_game;
        counter_activated = false;
    }

    void continue_game()
    {
        counter_activated = true;
        if (ball_show != null)
            ball_show();
        if (pong_show != null)
            pong_show();
    }

    void loose()
    {
        counter_activated = false;
        if (ball_hide != null)
            ball_hide();

        if (actual_event == 2)
        {
            if (effects_hideParticles != null)
                effects_hideParticles();
        }
        else if (actual_event == 4)
        {
            if (effects_hideSmoke != null)
                effects_hideSmoke();
        }
        else if (actual_event == 6)
        {
            if (effects_hideSpin != null)
                effects_hideSpin();
        }
    }

    public void showSpin()
    {
        if (effects_showSpin != null)
            effects_showSpin();
    }
    public void showParticles()
    {
        if (effects_showParticles != null)
            effects_showParticles();
    }
    public void showBall()
    {
        if (ball_show != null)
            ball_show();
    }


    void ballStarted()
    {
        counter_activated = true;

        moved_down = false;

        timeSinceMove = 0;
        actual_event = 1;

        if(pong_show != null)
            pong_show();


    }

    void ballShow()
    {
       
        if (ball_show != null)
            ball_show();
    }

    bool canDoEvent(int actualevent, float timeForThisEvent )
    {
        if (actual_event == actualevent && timeSinceMove > timeForThisEvent)
        {
            randomSecs = Random.Range(-0.5f, 0.5f);
            actual_event++;
            lastEventTime = timeForThisEvent;
            return true;
        }
        else return false;        
    }

    void Update()
    {
        if (counter_activated)
        {
/*          if (canDoEvent(0, 5.3f))
            {
                if(ball_newDirection_message != null)
                   ball_newDirection_message();
            }
            else */if (canDoEvent(1, 20 + randomSecs))
            {
                if(effects_showParticles != null)
                   effects_showParticles();
            }
            else if (canDoEvent(2, 24 + randomSecs))
            {
                if(effects_hideParticles != null)
                   effects_hideParticles();

                if (timeSinceMove - lastEventTime > 5)
                    achievements.setAchievement(achievementsManager.achievement.galaxy);
            }
            else if(canDoEvent(3, 37 + randomSecs))
            {
                if(effects_showSmoke != null)
                   effects_showSmoke();
            }
            else if(canDoEvent(4, 41 + randomSecs))
            {
                if(effects_hideSmoke != null)
                   effects_hideSmoke();

                if (timeSinceMove - lastEventTime > 5)
                    achievements.setAchievement(achievementsManager.achievement.smoke);
            }
            else if(canDoEvent(5, 55 + randomSecs))
            {
                if(effects_showSpin != null)
                   effects_showSpin();
                if (moved_down)
                {
                    if (border_stopMoveDown != null)
                        border_stopMoveDown();
                }
            }
            else if (canDoEvent(6, 59 + randomSecs))
            {
                if(effects_hideSpin != null)
                   effects_hideSpin();

                if (timeSinceMove - lastEventTime > 5)
                    achievements.setAchievement(achievementsManager.achievement.spin);

                timeSinceMove = 15;
                actual_event = 1;

                if (!moved_down)
                { 
                    if (border_moveDown != null)
                        border_moveDown();
                    moved_down = true;
                }

            }
            timeSinceMove += Time.deltaTime;
        }
    }

}
