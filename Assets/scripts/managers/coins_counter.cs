using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Coins_counter : MonoBehaviour {
    [SerializeField] GameManager levelMan;
    [SerializeField] Text text;
    [SerializeField] GameObject spriteObj;
    [SerializeField] AudioSource coinSound;

    // Use this for initialization
    void Start()
    {
        EventsExecute.Instance.data.SetEnter("show coins", Show);
        GameManager.addedCoinEvent += AddedCoin;
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
