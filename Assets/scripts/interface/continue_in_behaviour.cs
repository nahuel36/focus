using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class continue_in_behaviour : MonoBehaviour {

    public Text text;
    public float time;
    public EventsExecute events;

	// Use this for initialization
	void Start ()
    {
        time = 3.2f;
        text.text = LocalizationManager.GetWord(LocalizationManager.words.continuein_continue_in) + time.ToString("F3");
	}
	
	// Update is called once per frame
	void Update ()
    {
        text.text = LocalizationManager.GetWord(LocalizationManager.words.continuein_continue_in) + time.ToString("F3");
        time -= Time.deltaTime;
        if (time < 0)
        {
            events.PressContinue();
            this.gameObject.SetActive(false);
        }
    }
}
