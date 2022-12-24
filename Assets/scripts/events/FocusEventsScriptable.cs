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
    public FocusEvent[] OnEnd;
    public FocusEvent[] ResultsToMenu;

    public Dictionary<string, FocusEvent> OnApplicationStartEvents;
    public Dictionary<string, FocusEvent> OnStartPressedEvents;
}
