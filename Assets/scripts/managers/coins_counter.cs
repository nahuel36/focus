using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class coins_counter : MonoBehaviour {
    public gameManager levelMan;
    public Text text;
    public GameObject spriteObj;
    public AudioSource coinSound;

    // Use this for initialization
    void Start()
    {
        gameManager.addedCoin += AddedCoin;
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
        spriteObj.SetActive(false);
        text.text = "";

    }

    public void Show()
    {
        spriteObj.SetActive(true);
        text.text = levelMan.Coins.ToString();

    }




}
