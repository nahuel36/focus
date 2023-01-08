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
        events.data.SetEnter("Lab36 Logo",ShowLogo);
        events.data.SetEnter("Show Menu",ShowMenu);
        events.data.SetEnter("Show Game UI",ShowGame);
        events.data.SetEnter("Show Results",ShowResults);
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
            events.data.EndEvent("Lab36 Logo");
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Show Menu") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99f)
        {
            events.data.EndEvent("Show Menu");
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Show Game") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99f)
        {
            events.data.EndEvent("Show Game UI");
        }

    }
}
