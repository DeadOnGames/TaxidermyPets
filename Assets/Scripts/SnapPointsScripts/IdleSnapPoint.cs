using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleSnapPoint : SnapPoint
{
    public override void Snap(Draggable objectToSnap)
    {
        if (!isTriggered)
        {
            base.Snap(objectToSnap);

            //Stop all timers
            //timerParent.PauseAllTimers();
           
            //objectToSnap.transform.position = transform.position; // Snap into position
            objectToSnap.transform.localPosition = transform.localPosition;
        }
    }
}
