using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Localization;
public class TimeInMenu : MonoBehaviour {
    [SerializeField] PointsCounter points;
    private Text text;
    [SerializeField] LocalizedString menu_best_time;

    void Start () {
        text = GetComponent<Text>();
        text.text = menu_best_time.GetLocalizedString() + ":\n " + points.bestPoints.ToString("F0");

    }

}
