using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class betaVersionText : MonoBehaviour {
    Text betaText;
	// Use this for initialization
	void Start () {
        betaText = gameObject.GetComponent<Text>();
        betaText.text = "version: " + Application.version.ToString();
	}
	
}
