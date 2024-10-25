using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Localization;
public class TimeInResults : MonoBehaviour {
        
    [SerializeField] PointsCounter points;
    [SerializeField] Text text;
    [SerializeField] LocalizedString results_your_time;
    [SerializeField] LocalizedString results_best_time;
    
    public void Show()
    {
        text.text = results_your_time.GetLocalizedString() + "\n " + 
            points.actualPoints.ToString() + "\n" + 
            results_best_time.GetLocalizedString() + "\n " + 
            points.bestPoints.ToString();
         
    }

}


