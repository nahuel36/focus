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
        for (int i = 0; i < data.Conditions.Length; i++)
        {
            if(data.Conditions[i].condition == condition)
            {
                if(data.Conditions[i].waitToFinish)
                {
                    await ExecuteAndWait(data.Conditions[i]);
                }
                else
                {
                    ExecuteAndWait(data.Conditions[i]);
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
        for (int i = 0; i < eventsArray.Length; i++)
        {
            if (eventsArray[i].waitToFinish)
            {
                await ExecuteAndWait(eventsArray[i]);
            }
            else
            {
                ExecuteAndWait(eventsArray[i]);
            }
        }
    }





}
