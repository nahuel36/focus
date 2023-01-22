using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class EventsExecute : MonoBehaviour
{
    public FocusEventsScriptable data;
    bool isPaused = false;
    static EventsExecute instance;
    int actualGameCycle = 0;
    public static EventsExecute Instance
    {
        get {return instance; }
    }


    void Awake()
    {
        instance = this;
        actualGameCycle = 0;
        //data.FillDictionaries();
        data.SetEnter("start gamecycle", BeginCycle);
        data.SetEnter("resume gamecycle", Resume);
        data.SetEnter("pause gamecycle", Pause);
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
        isPaused = false;
        ExecuteEvents(data.OnApplicationStart);
    }

    public void Pause()
    {
        isPaused = true;
    }

    public void Resume() 
    {
        isPaused = false;
    }

    public async void BeginCycle()
    {
        isPaused = false;
        actualGameCycle++;
        int internalGameCycle = actualGameCycle;
        while(internalGameCycle == actualGameCycle)
        {
            await ExecuteEvents(data.GameCycle, true, true, internalGameCycle);
            await Task.Yield();
        }
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

    async Task ExecuteAndWait(FocusEvent actual_event, bool canPause = false, bool isGameCycle = false, int gamecycle = 0)
    {
        actual_event.ExecuteOnEnter();
        float counter = 0;
        if (!actual_event.customWait)
        {
            while (counter < actual_event.duration)
            {
                if(!isPaused || !canPause)
                    counter += Time.deltaTime;
                if (isGameCycle && actualGameCycle != gamecycle) 
                    return;
                await Task.Yield();
            }
        }
        else
        {
            while (!actual_event.ended)
            { 
                await Task.Yield();
                if (isGameCycle && actualGameCycle != gamecycle)
                    return;
            }
        }
        actual_event.ExecuteOnLeave();
    }

    async Task ExecuteEvents(FocusEvent[] eventsArray, bool canPause = false, bool isGameCycle = false, int gamecycle = 0)
    {
        foreach (FocusEvent evento in eventsArray)
        {
            if (isGameCycle && actualGameCycle != gamecycle) return;

            if (evento.waitToFinish)
            {
                await ExecuteAndWait(evento, canPause, isGameCycle, gamecycle);
            }
            else
            {
                ExecuteAndWait(evento, canPause);
            }
        }
    }





}
