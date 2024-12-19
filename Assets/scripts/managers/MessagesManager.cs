using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Localization;
public class MessagesManager : MonoBehaviour {

    //public Text game_TopText;
    [SerializeField] TextMeshProUGUI game_TopText2;
    //public Text game_BottomText;
    [SerializeField] TextMeshProUGUI game_BottomText2;
    [SerializeField] Animator gameBottomTextAnim;

    [SerializeField] Text game_achivUnlocked;

    [SerializeField] Coins_counter Coins;

    [SerializeField] LocalizedString game_focus_on_ball;

    [SerializeField] LocalizedString game_hold_here;
    [SerializeField] LocalizedString game_move_finger;
    [SerializeField] LocalizedString game_dont_let_it_fall;
    [SerializeField] LocalizedString game_beware;
    // Use this for initialization
    void Start()
    {
        EventsExecute.Instance.data.SetEnter("focus on ball message", startingGame);
        EventsExecute.Instance.data.SetEnter("dont let it fall message", ballStartMoving);
        EventsExecute.Instance.data.SetEnter("ball start x dir message",ballChangeDirection);
        EventsExecute.Instance.data.SetEnter("hide swipe message", hideSwipeMessage);
        EventsExecute.Instance.data.SetEnter("beware message", beware);
        EventsExecute.Instance.data.SetEnter("show swipe text",showHold);
        EventsExecute.Instance.data.SetEnter("hide all texts", hideAll);
        //gameEvents.ball_newDirection_message += ballChangeDirection;

        hideAchiv();

    }

    private void hideAll()
    {
        game_achivUnlocked.gameObject.SetActive(false);
        game_TopText2.text = "";
      //  game_BottomText.text = "";
        game_BottomText2.text = "";
        Coins.Hide();
    }

    
    public void achivUnlocked()
    {
        game_achivUnlocked.gameObject.SetActive(true);
        Invoke("hideAchiv",5);

    }

    void hideAchiv()
    {
        game_achivUnlocked.gameObject.SetActive(false);
    }


    void startingGame()
    {
        game_TopText2.text = game_focus_on_ball.GetLocalizedString();
        //timer.Hide();
        //Coins.Hide();
    }

    void showHold()
    {
        game_TopText2.text = "";
        gameBottomTextAnim.SetTrigger("show");
       // game_BottomText.text = LocalizationManager.GetWord(LocalizationManager.words.game_hold_here);
        game_BottomText2.text = game_hold_here.GetLocalizedString(); 
    }

    void ballStartMoving()
    {
        game_TopText2.text = game_dont_let_it_fall.GetLocalizedString();
    }

    void hideSwipeMessage()
    {
        gameBottomTextAnim.SetTrigger("hide");
    }

    void ballChangeDirection()
    {
        game_TopText2.text = game_move_finger.GetLocalizedString(); 
    }

    void beware()
    {
        game_TopText2.text = game_beware.GetLocalizedString();
        Invoke("hideMakeBestTime", 4);
    }

    void hideMakeBestTime()
    {
        game_TopText2.text = "";

    }

 


}
