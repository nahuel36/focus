using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeInResults : MonoBehaviour {
        
    public PointsCounter points;
    private Text text;

    void Start()
    {
        GameManager.loose += Show;
        text = GetComponent<Text>();
        Show();

    }
    
    void Show()
    {
        text.text = LocalizationManager.GetWord(LocalizationManager.words.results_your_time) + "\n " + 
            points.actualPoints.ToString() + "\n" + 
            LocalizationManager.GetWord(LocalizationManager.words.results_best_time) + "\n " + 
            points.bestPoints.ToString();
         
    }

}


