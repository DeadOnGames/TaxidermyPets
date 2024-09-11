using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SnapPoint : MonoBehaviour
{
    public int id;
    public PointType snapPointType;
    public TimerController AssociatedTimer;

    public SnapPoint teleportDestination;

    private TimerParentController timerParent;


    private void Start()
    {
        timerParent = FindObjectOfType<TimerParentController>();
    }

    public void SnapPointTriggered(Draggable animal)
    {
        Debug.Log($"Snap point {id} has been triggered");

        switch (snapPointType)
        {
            case PointType.Idle:
                //Stop all timers
                timerParent.PauseAllTimers();
                break;
            case PointType.Timed:
                if (AssociatedTimer != null) AssociatedTimer.StartTimer();
                break;
            case PointType.Teleporter:
                //Stop all timers
                timerParent.PauseAllTimers();
                //TODO: Check station complete
                //Teleport object
                if (teleportDestination != null) animal.TeleportAnimal(teleportDestination.transform.localPosition); 
                break;
            case PointType.Accessories: 
                //Todo: Need to add funcitonality later
                break;
        }
    }
}

public enum PointType
{
    Idle, Timed, Teleporter, Accessories
};
