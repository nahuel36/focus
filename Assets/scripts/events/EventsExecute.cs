using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class EventsExecute : MonoBehaviour
{
    [SerializeField] FocusEvent[] OnApplicationStart;
    [SerializeField] FocusEvent[] OnStartPressed;
    [SerializeField] FocusEvent[] GameCycle;
    [SerializeField] FocusEvent[] OnGameContinue;
    [SerializeField] FocusEvent[] OnEnd;
    [SerializeField] FocusEvent[] ResultsToMenu;
    [SerializeField] FocusEvent[] Tutorial;

    public Dictionary<string, FocusEvent> OnApplicationStartEvents;
    public Dictionary<string, FocusEvent> OnStartPressedEvents;

    void Awake()
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

    public void PressStart()
    {
        ExecuteEvents(OnStartPressed);
    }

    async void Start()
    {
        ExecuteEvents(OnApplicationStart);
    }

    async Task WaitAndEndEvent(FocusEvent actual_event)
    {
        if (!actual_event.customWait)
            await Task.Delay(System.TimeSpan.FromSeconds(actual_event.duration));
        else
        {
            while (!actual_event.ended)
                await Task.Yield();
        }
        actual_event.ExecuteOnLeave();
    }

    async void ExecuteEvents(FocusEvent[] eventsArray)
    {
        for (int i = 0; i < eventsArray.Length; i++)
        {
            eventsArray[i].ExecuteOnEnter();
            if (eventsArray[i].waitToFinish)
            {
                await WaitAndEndEvent(eventsArray[i]);
            }
            else
            {
                WaitAndEndEvent(eventsArray[i]);
            }
        }
    }





}
