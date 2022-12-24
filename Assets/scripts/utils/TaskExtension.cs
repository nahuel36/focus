using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public static class TaskExtension 
{
    public static async void WrapErrors(this Task task)
    {
        await task;
    }
    
}
