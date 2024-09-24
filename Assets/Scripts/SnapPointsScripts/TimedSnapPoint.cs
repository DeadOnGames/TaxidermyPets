using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSnapPoint : SnapPoint
{
    public TimerController AssociatedTimer;

    public override void Snap(Draggable objectToSnap)
    {
        if (!isTriggered)
        {
            base.Snap(objectToSnap);
            objectToSnap.transform.position = transform.position; // Snap into position
            if (AssociatedTimer != null)
            {
                AssociatedTimer.StartTimer();
            }
        }
    }

    public override void Release()
    {
        base.Release();
        AssociatedTimer.PauseTimer();
    }
}

