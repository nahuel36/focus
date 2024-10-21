using UnityEngine;
using System.Collections;


public class Results_continue_button : MonoBehaviour {

    public int presedTimes;
    private int presedMax = 3;
    public GameManager man;
    public bool passed30 = false;
    public bool continue_pressed = false;
    public GameObject button;

	// Use this for initialization
	void Start ()
    {
        EventsExecute.Instance.data.SetEnter("show continue button if can", loose);
        EventsExecute.Instance.data.SetEnter("reset continue button", startPresed);
        EventsExecute.Instance.data.SetEnter("continue button hide", continuePresed);
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
        
        if (/*presedTimes >= presedMax && passed30 && */!continue_pressed)
        {
            button.SetActive(true);
        }
        else
        {
            button.SetActive(false);
        }

    }

  
}
