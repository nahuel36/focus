using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FocusEventConditional : FocusEvent
{ 
    public enum Condition
    {
        ball_dirx_zero_and_collide_with_top,
        starting_showedswipe_and_clicked
    }

    public Condition condition;
}

[System.Serializable]
public class FocusEvent 
{
    public string name;
    public double duration;
    public delegate void EventDelegate();
    public event EventDelegate OnEnter;
    public event EventDelegate OnLeave;
    public bool waitToFinish = true;
    public bool customWait = false;
    public bool onlyForTutorial = false;
    internal bool ended = false;
    public void ExecuteOnEnter()
    {
        ended = false;
        OnEnter?.Invoke();
    }

    public void ExecuteOnLeave()
    {
        ended = true;
        OnLeave?.Invoke();
    }
}
