using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Linq;
public class EventsExecute : MonoBehaviour
{
    public FocusEventsScriptable data;
    public FocusEventsScriptable normal_data;
    public FocusEventsScriptable editor_data;
    bool isPaused = false;
    static EventsExecute instance;
    int actualGameCycle = 0;
    bool forceDontShuffle;
    public static EventsExecute Instance
    {
        get {return instance; }
    }


    void Awake()
    {
#if UNITY_EDITOR
        data = editor_data;
#else
        data = normal_data;
#endif
        instance = this;
        actualGameCycle = 0;
        //data.FillDictionaries();
        data.SetEnter("start gamecycle", BeginCycle);
        data.SetEnter("resume gamecycle", Resume);
        data.SetEnter("pause gamecycle", Pause);
        data.SetEnter("shuffle game cycle manual", gameCycleShuffleManual);
        data.SetEnter("no shuffle game cycle", gameCycleShuffleForceDont);
        
    }
    public void gameCycleShuffleManual()
    { 
        forceDontShuffle = false;
    }

    public void gameCycleShuffleForceDont()
    {
        forceDontShuffle = true;
    }

    public void EndGame()
    {
        ExecuteEvents(data.OnEndGame);
    }

    public void PressStart()
    {
        ExecuteEvents(data.OnStartPressed);
    }

    public void PressDebug()
    {
        ExecuteEvents(data.StartDebugMode);
    }
    public void PressContinue()
    {
        ExecuteEvents(data.OnGameContinue);
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
            FocusEvent[] gameCycleEvents = data.GameCycle;
            if (data.ShuffleGameCycle && !forceDontShuffle) gameCycleEvents = ArrayUtils.ShuffleFocusEvents(data.GameCycle);
            await ExecuteEvents(gameCycleEvents, true, true, internalGameCycle);
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
                if(isGameCycle && actualGameCycle == gamecycle) await ExecuteEvents(data.PrepareEffect,canPause,false,gamecycle);
                await ExecuteAndWait(evento, canPause, isGameCycle, gamecycle);
                if (isGameCycle && actualGameCycle == gamecycle)
                {
                    float counter = 0;
                    while (counter < data.TimeBetweenCycleEvent)
                    {
                        if (isGameCycle && actualGameCycle != gamecycle)
                            return;
                        if (!isPaused || !canPause)
                            counter += Time.deltaTime;
                        await Task.Yield();
                    }
                    
                }
            }
            else
            {
                ExecuteAndWait(evento, canPause);
            }

            
        }
    }





}
