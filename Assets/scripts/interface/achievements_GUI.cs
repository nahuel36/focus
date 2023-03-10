using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Achievements_GUI : MonoBehaviour {

    public Text Description;
    public AchievementsManager AchievMan;
    public Button[] achivButtons;
    
    // Use this for initialization
    public void Start () {
        int achievEarned = 0;

        for (int i = 0; i < AchievMan.achievements.Length; i++)
        {
            if (AchievMan.achievements[i] == true)
            { 
                achievEarned++;
                achivButtons[i].transform.GetChild(1).gameObject.SetActive(true);
            }
            else
                achivButtons[i].transform.GetChild(1).gameObject.SetActive(false);
        }

        Description.text = "you have " + achievEarned.ToString() + " trophies earned"; 
    }
	
	// Update is called once per frame
	public void setDescription (int word) {
        Description.text = LocalizationManager.GetWord(LocalizationManager.words.achiv_30seconds_description + word);
	}
}
