using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Confirmation_behaviour : MonoBehaviour {

    public GameObject GUI;
    public Text text;
    public PayManager payMan;
    public string action;

	// Use this for initialization
	public void Show (string what)
    {
        action = what;
        GUI.SetActive(true);
        if (what == "continue")
            text.text = LocalizationManager.GetWord(LocalizationManager.words.confirmation_tocontinue);

	}

    public void Hide()
    {
        GUI.SetActive(false);
    }

    // Update is called once per frame
    public void pay()
    {
        payMan.pay(action);    
	}

}
