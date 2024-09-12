using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterSnapPoint : SnapPoint
{
    public SnapPoint teleportDestination;

    public override void Snap(Draggable objectToSnap)
    {
        if (!isTriggered)
        {
            base.Snap(objectToSnap);
            objectToSnap.transform.position = transform.position; // Snap into place
            TeleportObject(objectToSnap);
        }
    }

    private void TeleportObject(Draggable objectToTeleport)
    {
        objectToTeleport.transform.position = teleportDestination.transform.position;
        // Additional logic for teleportation
    }
}

