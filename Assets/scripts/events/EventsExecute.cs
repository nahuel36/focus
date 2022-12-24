using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class EventsExecute : MonoBehaviour
{
    public FocusEventsScriptable data;

    void Awake()
    {
        data.OnApplicationStartEvents = new Dictionary<string, FocusEvent>();
        for (int i = 0; i < data.OnApplicationStart.Length; i++)
        {
            data.OnApplicationStartEvents.Add(data.OnApplicationStart[i].name, data.OnApplicationStart[i]);
        }

        data.OnStartPressedEvents = new Dictionary<string, FocusEvent>();
        for (int i = 0; i < data.OnStartPressed.Length; i++)
        {
            data.OnStartPressedEvents.Add(data.OnStartPressed[i].name, data.OnStartPressed[i]);
        }
    }

    public void PressStart()
    {
        ExecuteEvents(data.OnStartPressed);
    }

    async void Start()
    {
        ExecuteEvents(data.OnApplicationStart);
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
