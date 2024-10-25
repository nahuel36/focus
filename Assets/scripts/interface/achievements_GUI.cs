using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Localization;
public class Achievements_GUI : MonoBehaviour {

    [SerializeField] Text Description;
    [SerializeField] AchievementsManager AchievMan;
    [SerializeField] Button[] achivButtons;
    [SerializeField] LocalizedString achiv_30seconds_description;
    [SerializeField] LocalizedString achiv_60seconds_description;
    [SerializeField] LocalizedString achiv_120seconds_description;
    [SerializeField] LocalizedString achiv_300seconds_description;
    [SerializeField] LocalizedString achiv_1ponged_description;
    [SerializeField] LocalizedString achiv_2ponged_description;
    [SerializeField] LocalizedString achiv_3ponged_description;
    [SerializeField] LocalizedString achiv_galaxy_description;
    [SerializeField] LocalizedString achiv_smoke_description;
    [SerializeField] LocalizedString achiv_spin_description;
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
        string text = "";

        switch (word)
        {
            case 0:
                text = achiv_30seconds_description.GetLocalizedString();
                break;
            case 1:
                text = achiv_60seconds_description.GetLocalizedString();
                break;
            case 2:
                text = achiv_120seconds_description.GetLocalizedString();
                break;
            case 3:
                text = achiv_300seconds_description.GetLocalizedString();
                break;
            case 4:
                text = achiv_1ponged_description.GetLocalizedString();
                break;
            case 5:
                text = achiv_2ponged_description.GetLocalizedString();
                break;
            case 6:
                text = achiv_3ponged_description.GetLocalizedString();
                break;
            case 7:
                text = achiv_galaxy_description.GetLocalizedString();
                break;
            case 8:
                text = achiv_smoke_description.GetLocalizedString();
                break;
            case 9:
                text = achiv_spin_description.GetLocalizedString();
                break;
            default:
                break;
        }

        Description.text = text;
	}
}
