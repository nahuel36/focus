using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsLogger : MonoBehaviour
{

    private void Start()
    {
        EventsExecute.Instance.data.SetEnter("show time",LogEnter);
        EventsExecute.Instance.data.SetEnter("show time",LogEnd);
        EventsExecute.Instance.data.SetEnter("show time 2",LogEnter);
        EventsExecute.Instance.data.SetEnter("show time 2",LogEnd);
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
