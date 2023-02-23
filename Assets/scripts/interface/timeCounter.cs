using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class timeCounter : MonoBehaviour {
    public gameManager levelMan;
    public Text text;
    public Text best_text;

    public void Show()
    {
        InvokeRepeating("show", 0, 1);
    }

    public void Hide()
    {
        //text.text = "";
        //CancelInvoke();
    }

    // Update is called once per frame
    void show () {
        text.text = levelMan.actualTime.ToString("F0");
        best_text.text = levelMan.bestTime.ToString("F0");
    }
}
