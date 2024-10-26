using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
public static class ArrayUtils 
{
    public static FocusEvent[] ShuffleFocusEvents(FocusEvent[] cycle)
    {
        FocusEvent[] shuffledCycle = new FocusEvent[cycle.Length];
        List<FocusEvent> tempList = cycle.ToList<FocusEvent>();

        for (int i = 0; i < shuffledCycle.Length; i++)
        {
            int index = UnityEngine.Random.Range(0, tempList.Count);
            shuffledCycle[i] = tempList[index];
            tempList.RemoveAt(index);
        }

        return shuffledCycle;
    }
}
