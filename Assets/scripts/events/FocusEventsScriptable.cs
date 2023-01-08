using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EventsData", menuName = "ScriptableObjects/Events Data", order = 1)]
public class FocusEventsScriptable : ScriptableObject
{
    public FocusEvent[] OnApplicationStart;
    public FocusEvent[] OnStartPressed;
    public FocusEvent[] GameCycle;
    public FocusEvent[] OnGameContinue;
    public FocusEvent[] OnEndGame;
    public FocusEvent[] ResultsToMenu;
    public FocusEventConditional[] Conditions;
       

    List<FocusEvent> FindOnArray(FocusEvent[] eventarray, string eventname)
    {
        List<FocusEvent> list = new List<FocusEvent>();

        for (int i = 0; i < eventarray.Length; i++)
        {
            if (eventarray[i].name == eventname)
                list.Add(eventarray[i]);
        }
        return list;
    }

    void SetEnterOnArray(FocusEvent[] array, string eventname, FocusEvent.EventDelegate delegateFunc)
    {
        foreach(FocusEvent focusevent in FindOnArray(array, eventname))
            focusevent.OnEnter += delegateFunc;
    }

    public void SetEnter(string eventname, FocusEvent.EventDelegate delegateFunc)
    {
        SetEnterOnArray(OnApplicationStart, eventname, delegateFunc);

        SetEnterOnArray(OnStartPressed, eventname, delegateFunc);

        SetEnterOnArray(GameCycle, eventname, delegateFunc);

        SetEnterOnArray(OnGameContinue, eventname, delegateFunc);
        
        SetEnterOnArray(OnEndGame, eventname, delegateFunc);

        SetEnterOnArray(ResultsToMenu, eventname, delegateFunc);

        SetEnterOnArray(Conditions, eventname, delegateFunc);
    }

    void EndEventOnArray(FocusEvent[] array, string eventname)
    {
        foreach (FocusEvent focusevent in FindOnArray(array, eventname))
            focusevent.ended = true;
    }

    public void EndEvent(string eventname)
    {
        EndEventOnArray(OnApplicationStart, eventname);

        EndEventOnArray(OnStartPressed, eventname);
        
        EndEventOnArray(GameCycle, eventname);

        EndEventOnArray(OnGameContinue, eventname);

        EndEventOnArray(OnEndGame, eventname);

        EndEventOnArray(ResultsToMenu, eventname);

        EndEventOnArray(Conditions, eventname);
    }

}
