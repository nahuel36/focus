using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Localization;
public class Continue_in_behaviour : MonoBehaviour {

    [SerializeField] Text text;
    [SerializeField] float time;
    [SerializeField] EventsExecute events;
    [SerializeField] LocalizedString continue_in;
	// Use this for initialization
	void Start ()
    {
        time = 3.2f;
        text.text = continue_in.GetLocalizedString() + time.ToString("F3");
	}
	
	// Update is called once per frame
	void Update ()
    {
        text.text = continue_in.GetLocalizedString() + time.ToString("F3");
        time -= Time.deltaTime;
        if (time < 0)
        {
            events.PressContinue();
            this.gameObject.SetActive(false);
        }
    }
}
