using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EventsData", menuName = "ScriptableObjects/Events Data", order = 1)]
public class FocusEventsScriptable : ScriptableObject
{
    [SerializeField]FocusEvent[] OnApplicationStart;
    [SerializeField]FocusEvent[] OnStartPressed;
    [SerializeField]FocusEvent[] GameCycle;
    [SerializeField]FocusEvent[] OnGameContinue;
    [SerializeField]FocusEvent[] OnEndGame;
    [SerializeField]FocusEvent[] ResultsToMenu;
    [SerializeField]FocusEventConditional[] Conditions;

    public Dictionary<string, FocusEvent> OnApplicationStartEvents;
    public Dictionary<string, FocusEvent> OnStartPressedEvents;
    public Dictionary<string, FocusEvent> OnContinuePressedEvents;
    public Dictionary<string, FocusEvent> OnEndGameEvents;
    public Dictionary<string, FocusEvent> ConditionsEvents;

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

        OnEndGameEvents = new Dictionary<string, FocusEvent>();
        for (int i = 0; i < OnEndGame.Length; i++)
        {
            OnEndGameEvents.Add(OnEndGame[i].name, OnEndGame[i]);
        }

        ConditionsEvents = new Dictionary<string, FocusEvent>();
        for (int i = 0; i < Conditions.Length; i++)
        {
            ConditionsEvents.Add(Conditions[i].name, Conditions[i]);
        }

        OnContinuePressedEvents = new Dictionary<string, FocusEvent>();
        for (int i = 0; i < OnGameContinue.Length; i++)
        {
            OnContinuePressedEvents.Add(OnGameContinue[i].name, OnGameContinue[i]);
        }
        
    }
}
