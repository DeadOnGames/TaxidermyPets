using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TaskRunner;

public class TimedSnapPoint : SnapPoint
{
    public TimerController associatedTimer;
    public enum TimedSnapPointType { washing, stuffing };
    public TimedSnapPointType type;


    public override void Snap(Draggable objectToSnap)
    {
        if (!isTriggered)
        {
            base.Snap(objectToSnap);
            objectToSnap.transform.position = transform.position; // Snap into position
            if (associatedTimer != null)
            {
                associatedTimer.StartTimer();
            }
        }
    }

    public override void Release(Draggable objectToRelease)
    {
        base.Release(objectToRelease);
        var scoreKeeper = objectToRelease.GetComponent<ScoreKeeper>();

        switch (type)
        {
            case TimedSnapPointType.washing:
                scoreKeeper.AddToWashingTime(associatedTimer.GetCurrentTime());
                break;
            case TimedSnapPointType.stuffing:
                scoreKeeper.AddStuffingTime(associatedTimer.GetCurrentTime());
                break;
        }
                
        associatedTimer.ResetTimer();
    }
}

