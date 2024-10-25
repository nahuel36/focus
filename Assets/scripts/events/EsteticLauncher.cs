using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsteticLauncher : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] TimeInResults timeInResults;
    // Start is called before the first frame update
    void Start()
    {
        EventsExecute.Instance.data.SetEnter("Lab36 Logo",ShowLogo);
        EventsExecute.Instance.data.SetEnter("Show Menu",ShowMenu);
        EventsExecute.Instance.data.SetEnter("Show Game UI",ShowGame);
        EventsExecute.Instance.data.SetEnter("Show Results",ShowResults);
        EventsExecute.Instance.data.SetEnter("Show Time Results", ShowTimeResults);
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

    public void ShowTimeResults()
    {
        timeInResults.Show();
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Lab36 Logo") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99f)
        {
            EventsExecute.Instance.data.EndEvent("Lab36 Logo");
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Show Menu") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99f)
        {
            EventsExecute.Instance.data.EndEvent("Show Menu");
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Show Game") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99f)
        {
            EventsExecute.Instance.data.EndEvent("Show Game UI");
        }

    }
}
