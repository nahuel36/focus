using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsLogger : MonoBehaviour
{
    [SerializeField]EventsExecute eventsContainer;

    private void Start()
    {
        eventsContainer.OnApplicationStartEvents["show time"].OnEnter += LogEnter;
        eventsContainer.OnApplicationStartEvents["show time"].OnLeave += LogEnd;
        eventsContainer.OnApplicationStartEvents["show time 2"].OnEnter += LogEnter;
        eventsContainer.OnApplicationStartEvents["show time 2"].OnLeave += LogEnd;
    }

    private void LogEnter()
    {
        Debug.Log(Time.realtimeSinceStartup);
    }

    private void LogEnd()
    {
        Debug.Log(Time.realtimeSinceStartup);
    }
}
