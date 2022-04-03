using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class stop_behaviour : MonoBehaviour {

    int times;
    private int maxTimes = 5;
    const float waitTime = 3;
    public Text timeText;
    public float time;

	// Use this for initialization
	void Start () {
        times = 0;
        gameManager.loose += Check;

	}
	
	// Update is called once per frame
	void Check() {
        //if (!Advertisement.isInitialized())
         //   return;
        
        times++;
        if (times == maxTimes)
        {
            Invoke("show", 1.5f);
            if (maxTimes > 3)
                maxTimes--; 
        }
    }

    void show()
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
        time = waitTime;
        InvokeRepeating("showText", 0, 0.1f);
    }

    void showText()
    {
        timeText.text = time.ToString("F3");
        time -= 0.001f;
        if(time <= 0)
        {
            Reset();
        }
    }

    public void Reset()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        times = 0;
        CancelInvoke();

    }
}
