using UnityEngine;
using UnityEngine.UI;

public class MessagesManager : MonoBehaviour {

    public Text game_TopText;
    public Text game_BottomText;
    public Animator gameBottomTextAnim;
    public timeCounter timer;

    public Text menu_start;
    public Text menu_extras;

    public Text extras_style;
    public Text extras_achievements;
    public Text extras_back;

    public Text style_changeBackground;
    public Text style_changeBall;
    public Text style_removeBanner;
    public Text style_back;

    public Text achiv_30seconds;
    public Text achiv_60seconds;
    public Text achiv_120seconds;
    public Text achiv_300seconds;
    public Text achiv_1ponged;
    public Text achiv_2ponged;
    public Text achiv_3ponged;
    public Text achiv_galaxy;
    public Text achiv_smoke;
    public Text achiv_spin;
    public Text achiv_share;
    public Text achiv_back;

    public Text coins_pack1;
    public Text coins_pack2;
    public Text coins_pack3;
    public Text coins_back;

    public Text coinsAdvice_toget;
    public Text coinsAdvice_ok;


    public Text game_achivUnlocked;

    public Text results_restart_Text;
    public Text results_you_loose;
	public Text results_share;
    public Text results_continue;

    public Text confirmation_message;
    public Text confirmation_yes;
    public Text confirmation_no;

    public coins_counter Coins;

    // Use this for initialization
    void Start()
    {
        EventsExecute.Instance.data.SetEnter("focus on ball message", startingGame);
        EventsExecute.Instance.data.SetEnter("dont let it fall message", ballStartMoving);
        EventsExecute.Instance.data.SetEnter("ball start x dir message",ballChangeDirection);
        EventsExecute.Instance.data.SetEnter("hide swipe message", hideSwipeMessage);
        EventsExecute.Instance.data.SetEnter("make best score message", makeBestTime);
        EventsExecute.Instance.data.SetEnter("show swipe text",showHold);
        EventsExecute.Instance.data.SetEnter("hide all texts", hideAll);
        //gameEvents.ball_newDirection_message += ballChangeDirection;

        timer.Hide();
        Coins.Hide();
        hideAchiv();

        menu_start.text = LocalizationManager.GetWord(LocalizationManager.words.menu_start);
        menu_extras.text = LocalizationManager.GetWord(LocalizationManager.words.menu_extras);

        extras_achievements.text = LocalizationManager.GetWord(LocalizationManager.words.extras_achievements);
        extras_back.text = LocalizationManager.GetWord(LocalizationManager.words.extras_back);
        extras_style.text = LocalizationManager.GetWord(LocalizationManager.words.extras_style);

        style_changeBackground.text = LocalizationManager.GetWord(LocalizationManager.words.style_changebackground);
        style_changeBall.text = LocalizationManager.GetWord(LocalizationManager.words.style_changeball);
        style_back.text = LocalizationManager.GetWord(LocalizationManager.words.extras_back);

        achiv_30seconds.text  = LocalizationManager.GetWord(LocalizationManager.words.achiv_30seconds);
        achiv_60seconds.text  = LocalizationManager.GetWord(LocalizationManager.words.achiv_60seconds);
        achiv_120seconds.text = LocalizationManager.GetWord(LocalizationManager.words.achiv_120seconds);
        achiv_300seconds.text = LocalizationManager.GetWord(LocalizationManager.words.achiv_300seconds);
        achiv_1ponged.text    = LocalizationManager.GetWord(LocalizationManager.words.achiv_1ponged);
        achiv_2ponged.text    = LocalizationManager.GetWord(LocalizationManager.words.achiv_2ponged);
        achiv_3ponged.text    = LocalizationManager.GetWord(LocalizationManager.words.achiv_3ponged);
        achiv_galaxy.text     = LocalizationManager.GetWord(LocalizationManager.words.achiv_galaxy);
        achiv_smoke.text      = LocalizationManager.GetWord(LocalizationManager.words.achiv_smoke);
        achiv_spin.text       = LocalizationManager.GetWord(LocalizationManager.words.achiv_spin);
        achiv_back.text       = LocalizationManager.GetWord(LocalizationManager.words.extras_back);
        achiv_share.text      = LocalizationManager.GetWord(LocalizationManager.words.results_share);

        coinsAdvice_toget.text = LocalizationManager.GetWord(LocalizationManager.words.coinsadvice_toget);
        coinsAdvice_ok.text = LocalizationManager.GetWord(LocalizationManager.words.coinsadvice_ok);

        results_restart_Text.text = LocalizationManager.GetWord(LocalizationManager.words.results_restart);
        results_you_loose.text = LocalizationManager.GetWord(LocalizationManager.words.results_you_loose);
		results_share.text = LocalizationManager.GetWord (LocalizationManager.words.results_share);
        results_continue.text = LocalizationManager.GetWord(LocalizationManager.words.results_continue);

        confirmation_message.text = LocalizationManager.GetWord(LocalizationManager.words.confirmation_tocontinue);
        confirmation_yes.text = LocalizationManager.GetWord(LocalizationManager.words.confirmation_yes);
        confirmation_no.text = LocalizationManager.GetWord(LocalizationManager.words.confirmation_no);

    }

    private void hideAll()
    {
        game_achivUnlocked.text = "";
        game_TopText.text = "";
        game_BottomText.text = "";
        timer.Hide();
        Coins.Hide();
    }

    
    public void achivUnlocked()
    {
        game_achivUnlocked.text = LocalizationManager.GetWord(LocalizationManager.words.game_achievement_unlocked);
        Invoke("hideAchiv",5);

    }

    void hideAchiv()
    {
        game_achivUnlocked.text = "";
    }


    void startingGame()
    {
        game_TopText.text = LocalizationManager.GetWord(LocalizationManager.words.game_focus_on_ball);
        timer.Hide();
        Coins.Hide();
    }

    void showHold()
    {
        game_TopText.text = "";
        gameBottomTextAnim.SetTrigger("show");
        game_BottomText.text = LocalizationManager.GetWord(LocalizationManager.words.game_hold_here);
        timer.Hide();
        Coins.Hide();
    }

    void ballStartMoving()
    {
        game_TopText.text = LocalizationManager.GetWord(LocalizationManager.words.game_dont_let_it_fall);
        timer.Hide();
        Coins.Hide();
    }

    void hideSwipeMessage()
    {
        gameBottomTextAnim.SetTrigger("hide");
    }

    void ballChangeDirection()
    {
        game_TopText.text = LocalizationManager.GetWord(LocalizationManager.words.game_move_finger);
        timer.Hide();
        Coins.Hide();
    }

    void makeBestTime()
    {
        game_TopText.text = LocalizationManager.GetWord(LocalizationManager.words.game_make_best_time);
        Invoke("hideMakeBestTime", 4);
        timer.Hide();
        Coins.Hide();
    }

    void hideMakeBestTime()
    {
        game_TopText.text = "";
        timer.Show();
        Coins.Show();
    }

 


}
