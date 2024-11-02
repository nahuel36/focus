using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Localization;
using System;
using UnityEngine.ResourceManagement.AsyncOperations;

public class TimeInMenu : MonoBehaviour {
    [SerializeField] PointsCounter points;
    private Text text;
    [SerializeField] LocalizedString menu_best_time;
    
    void Start () {
        text = GetComponent<Text>();
        var asyncString = menu_best_time.GetLocalizedStringAsync();
        asyncString.Completed += OnStringCompleted;
    }

    private void OnStringCompleted(AsyncOperationHandle<string> obj)
    {
        text.text = obj.Result +":\n " + points.bestPoints.ToString("F0");
    }
}
