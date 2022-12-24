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

    public Dictionary<string, FocusEvent> OnApplicationStartEvents;
    public Dictionary<string, FocusEvent> OnStartPressedEvents;

    public void FillDictionaries()
    {
        OnApplicationStartEvents = new Dictionary<string, FocusEvent>();
        for (int i = 0; i < OnApplicationStart.Length; i++)
        {
            OnApplicationStartEvents.Add(OnApplicationStart[i].name, OnApplicationStart[i]);
        }

        OnStartPressedEvents = new Dictionary<string, FocusEvent>();
        for (int i = 0; i < OnStartPressed.Length; i++)
        {
            OnStartPressedEvents.Add(OnStartPressed[i].name, OnStartPressed[i]);
        }
    }
}
