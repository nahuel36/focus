using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsteticLauncher : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] EventsExecute events;
    // Start is called before the first frame update
    void Start()
    {
        events.data.OnApplicationStartEvents["Lab36 Logo"].OnEnter += ShowLogo;
        events.data.OnApplicationStartEvents["Show Menu"].OnEnter += ShowMenu;
        events.data.OnStartPressedEvents["Show Game UI"].OnEnter += ShowGame;
        events.data.OnEndGameEvents["Show Results"].OnEnter += ShowResults;
    }

    private void ShowLogo()
    {
        animator.Play("Lab36 Logo");
    }

    private void ShowMenu()
    {
        animator.Play("Show Menu");
    }

    private void ShowGame()
    {
        animator.Play("Show Game");
    }

    public void ShowResults()
    {
        animator.Play("game-results", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Lab36 Logo") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99f)
        {
            events.data.OnApplicationStartEvents["Lab36 Logo"].ended = true;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Show Menu") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99f)
        {
            events.data.OnApplicationStartEvents["Show Menu"].ended = true;
        }
    }
}
