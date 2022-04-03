using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;
using GoogleMobileAds;


public class results_continue_button : MonoBehaviour {

    public int presedTimes;
    private int presedMax = 3;
    public gameManager man;
    public bool passed30 = false;
    public bool continue_pressed = false;
    public GameObject button;

	// Use this for initialization
	void Start ()
    {
        gameManager.continue_pressed += continuePresed;
        gameManager.startPressed += startPresed;
        gameManager.loose += loose;
    }

    void startPresed()
    {
        continue_pressed = false;
    }

    void continuePresed()
    {
        continue_pressed = true;
    }

    void loose()
    {
        presedTimes = man.startPresedTimes;

        if (man.actualTime > 30)
            passed30 = true;
        else
            passed30 = false;
        
        if (presedTimes >= presedMax && passed30 && !continue_pressed)
        {
            button.SetActive(true);
        }
        else
        {
            button.SetActive(false);
        }

    }

  
}
