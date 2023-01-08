using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsLogger : MonoBehaviour
{
    [SerializeField]EventsExecute eventsContainer;

    private void Start()
    {
        eventsContainer.data.SetEnter("show time",LogEnter);
        eventsContainer.data.SetEnter("show time",LogEnd);
        eventsContainer.data.SetEnter("show time 2",LogEnter);
        eventsContainer.data.SetEnter("show time 2",LogEnd);
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
