using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class EventsExecute : MonoBehaviour
{
    public FocusEventsScriptable data;

    void Awake()
    {
        data.FillDictionaries();
    }

    public void EndGame()
    {
        ExecuteEvents(data.OnEndGameEvents);
    }

    public void PressStart()
    {
        ExecuteEvents(data.OnStartPressedEvents);
    }

    async void Start()
    {
        ExecuteEvents(data.OnApplicationStartEvents);
    }

    public async void ExecuteConditional(FocusEventConditional.Condition condition)
    {
        foreach (FocusEventConditional evento in data.ConditionsEvents.Values)
        {
            if(evento.condition == condition)
            {
                if(evento.waitToFinish)
                {
                    await ExecuteAndWait(evento);
                }
                else
                {
                    ExecuteAndWait(evento);
                }
            }
        }
    }

    async Task ExecuteAndWait(FocusEvent actual_event)
    {
        actual_event.ExecuteOnEnter();
        if (!actual_event.customWait)
            await Task.Delay(System.TimeSpan.FromSeconds(actual_event.duration));
        else
        {
            while (!actual_event.ended)
                await Task.Yield();
        }
        actual_event.ExecuteOnLeave();
    }

    async void ExecuteEvents(Dictionary<string, FocusEvent> eventsArray)
    {
        foreach (FocusEvent evento in eventsArray.Values)
        {
            if (evento.waitToFinish)
            {
                await ExecuteAndWait(evento);
            }
            else
            {
                ExecuteAndWait(evento);
            }
        }
    }





}
