using UnityEngine;
using System.Collections;

public class Coins_advice_behaviour : MonoBehaviour {

    public Confirmation_behaviour confirmation;
    public GameObject content;
    public GameObject coins_packs;

	// Use this for initialization
	public void Show () {
        content.SetActive(true);
	}

    public void ok()
    {
        content.SetActive(false);
        confirmation.Hide();
    }

    public void showPacks()
    {
        content.SetActive(false);
        coins_packs.SetActive(true);
    }
	
    
	
}
