using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class EventsExecute : MonoBehaviour
{
    public FocusEventsScriptable data;

    void Awake()
    {
        //data.FillDictionaries();
    }

    public void EndGame()
    {
        ExecuteEvents(data.OnEndGame);
    }

    public void PressStart()
    {
        ExecuteEvents(data.OnStartPressed);
    }

    async void Start()
    {
        ExecuteEvents(data.OnApplicationStart);
    }

    public async void ExecuteConditional(FocusEventConditional.Condition condition)
    {
        foreach (FocusEventConditional evento in data.Conditions)
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

    async void ExecuteEvents(FocusEvent[] eventsArray)
    {
        foreach (FocusEvent evento in eventsArray)
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
