using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Localization;
public class TimeInResults : MonoBehaviour {
        
    [SerializeField] PointsCounter points;
    private Text text;
    [SerializeField] LocalizedString results_your_time;
    [SerializeField] LocalizedString results_best_time;
    void Start()
    {
        GameManager.loose += Show;
        text = GetComponent<Text>();
        Show();

    }
    
    void Show()
    {
        text.text = results_your_time.GetLocalizedString() + "\n " + 
            points.actualPoints.ToString() + "\n" + 
            results_best_time.GetLocalizedString() + "\n " + 
            points.bestPoints.ToString();
         
    }

}


