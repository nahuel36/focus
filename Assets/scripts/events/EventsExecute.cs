using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class EventsExecute : MonoBehaviour
{
    public FocusEventsScriptable data;
    bool isPaused = false;
    static EventsExecute instance;
    int cycleCounter = 0;
    public static EventsExecute Instance
    {
        get {return instance; }
    }


    void Awake()
    {
        instance = this;
        cycleCounter = 0;
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
        cycleCounter++;
        while(true)
        {
            await ExecuteEvents(data.GameCycle, true, true, cycleCounter);
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

    async Task ExecuteAndWait(FocusEvent actual_event, bool canPause = false)
    {
        actual_event.ExecuteOnEnter();
        float counter = 0;
        if (!actual_event.customWait)
        {
            while (counter < actual_event.duration)
            {
                if(!isPaused || !canPause)
                    counter += Time.deltaTime;
                await Task.Yield();
            }
        }
        else
        {
            while (!actual_event.ended)
                await Task.Yield();
        }
        actual_event.ExecuteOnLeave();
    }

    async Task ExecuteEvents(FocusEvent[] eventsArray, bool canPause = false, bool isGameCycle = false, int ActualCycleCounter = 0)
    {
        if (isGameCycle && cycleCounter != ActualCycleCounter) return;

        foreach (FocusEvent evento in eventsArray)
        {
            if (evento.waitToFinish)
            {
                await ExecuteAndWait(evento, canPause);
            }
            else
            {
                ExecuteAndWait(evento, canPause);
            }
        }
    }





}
