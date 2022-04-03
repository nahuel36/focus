using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class timeinmenu : MonoBehaviour {
    public gameManager levelMan;
    private Text text;

    void Start () {
        text = GetComponent<Text>();
        text.text = LocalizationManager.GetWord(LocalizationManager.words.menu_best_time) + ":\n " + levelMan.bestTime.ToString("F3");

    }

}
