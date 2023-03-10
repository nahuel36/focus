using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Coins_counter : MonoBehaviour {
    public GameManager levelMan;
    public Text text;
    public GameObject spriteObj;
    public AudioSource coinSound;

    // Use this for initialization
    void Start()
    {
        GameManager.addedCoin += AddedCoin;
    }

    public void AddedCoin()
    {
        coinSound.Play();
        text.text = levelMan.Coins.ToString();
        spriteObj.SetActive(true);
    }

    // Update is called once per frame
    public void Hide ()
    {
       // spriteObj.SetActive(false);
       // text.text = "";

    }

    public void Show()
    {
        spriteObj.SetActive(true);
        text.text = levelMan.Coins.ToString();

    }




}
