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
        events.OnApplicationStartEvents["Lab36 Logo"].OnEnter += ShowLogo;
        events.OnApplicationStartEvents["Show Menu"].OnEnter += ShowMenu;
        events.OnStartPressedEvents["gamemanager start"].OnEnter += ShowGame;
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

    // Update is called once per frame
    void Update()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Lab36 Logo") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99f)
        {
            events.OnApplicationStartEvents["Lab36 Logo"].ended = true;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Show Menu") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99f)
        {
            events.OnApplicationStartEvents["Show Menu"].ended = true;
        }
    }
}
