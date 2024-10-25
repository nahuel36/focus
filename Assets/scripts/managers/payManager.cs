using UnityEngine;
using System.Collections;

public class PayManager : MonoBehaviour {

    
    public GameManager gameMan;
    public Confirmation_behaviour confirmation;
    public Coins_counter coins_counter;
    public Coins_advice_behaviour coins_advice;
    public GameObject continue_counterGUI;

    private void not_enough_money()
    {
        coins_advice.Show();
    }

    public void showConfirmation(string what) {
        confirmation.Show(what);
        coins_counter.Show();
    }

    // Use this for initialization
	public void pay (string action) {
        confirmation.Hide();
        if (action == "continue" && checkPay(5))
        {
            continue_counterGUI.SetActive(true);
        }
        /*else if (action == "changeBackground1" && checkPay(25))
        {

        }
        else if (action == "changeBackground2" && checkPay(40))
        {

        }
        else if (action == "changeBall1" && checkPay(35))
        {

        }
        else if (action == "changeBall2" && checkPay(50))
        {

        }*/
    }

    bool checkPay(int quantity)
    {
        if (gameMan.Coins < quantity)
        {
            not_enough_money();
            Debug.Log("not money");
            return false;
        }
        else
        {
            gameMan.Coins -= quantity; 
            return true;
        }
    }
    

	// Update is called once per frame
	void Update () {
	
	}
}
