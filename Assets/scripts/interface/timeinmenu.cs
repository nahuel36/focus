using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeInMenu : MonoBehaviour {
    public PointsCounter points;
    private Text text;

    void Start () {
        text = GetComponent<Text>();
        text.text = LocalizationManager.GetWord(LocalizationManager.words.menu_best_time) + ":\n " + points.bestPoints.ToString("F0");

    }

}
