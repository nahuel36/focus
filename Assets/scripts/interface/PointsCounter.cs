using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class PointsCounter : MonoBehaviour {
    public GameManager levelMan;
    public Text text;
    public Text best_text;

    public int bestPoints;
    public int actualPoints;
    public void Start()
    {
        Reset();

        EventsExecute.Instance.data.SetEnter("reset points", Reset);
    }

    public void Reset()
    {
        bestPoints = PlayerPrefs.GetInt("best");
        actualPoints = 0;
        text.text = actualPoints.ToString();
        best_text.text = bestPoints.ToString();
    }

    public void Hide()
    {
        //text.text = "";
        //CancelInvoke();
    }

    public void AddPoint(int cuantity)
    {
        actualPoints += cuantity;
        if (actualPoints > bestPoints)
        { 
            PlayerPrefs.SetInt("best", actualPoints);
            bestPoints = actualPoints;
        }
        text.text = actualPoints.ToString();
        best_text.text = bestPoints.ToString();
    }


}
