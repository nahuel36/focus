using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Localization;
public class Confirmation_behaviour : MonoBehaviour {

    [SerializeField] GameObject GUI;
    [SerializeField] Text text;
    [SerializeField] PayManager payMan;
    [SerializeField] string action;
    [SerializeField] LocalizedString confirmation_tocontinue;
    // Use this for initialization
    public void Show (string what)
    {
        action = what;
        GUI.SetActive(true);
        if (what == "continue")
            text.text = confirmation_tocontinue.GetLocalizedString();

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
