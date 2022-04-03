using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class timeInResults : MonoBehaviour {
        
    public gameManager levelMan;
    private Text text;

    void Start()
    {
        gameManager.loose += Show;
        text = GetComponent<Text>();
        Show();

    }
    
    void Show()
    {
        text.text = LocalizationManager.GetWord(LocalizationManager.words.results_your_time) + "\n " + 
            levelMan.actualTime.ToString("F3") + "\n" + 
            LocalizationManager.GetWord(LocalizationManager.words.results_best_time) + "\n " + 
            levelMan.bestTime.ToString("F3");
         
    }

}


