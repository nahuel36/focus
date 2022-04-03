using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class alternateModes : MonoBehaviour
{

    

    public Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
        gameManager.startPressed += HideMenuAnimation;
        gameManager.loose += showResults;
        gameManager.continue_pressed += HideMenuAnimation;
    }

    public void HideMenuAnimation()
    {
        anim.SetTrigger("game");
    }
    

    public void showResults()
    {
        anim.Play("game-results",0);
    }

   


}
