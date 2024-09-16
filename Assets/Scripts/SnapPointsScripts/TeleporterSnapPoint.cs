using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterSnapPoint : SnapPoint
{
    public SnapPoint teleportDestination;
    public float TeleportDuration = 2.0f;

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
        StartCoroutine(MoveToPosition(objectToTeleport, teleportDestination.transform.position, TeleportDuration));
    }

    private IEnumerator MoveToPosition(Draggable objectToMove, Vector3 targetPosition, float duration)
    {
        Vector3 startPosition = objectToMove.transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            objectToMove.transform.position = Vector3.Lerp(startPosition, startPosition + new Vector3(10,0,0), elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null; //Wait until next frame
        }

        objectToMove.transform.position = targetPosition;
    }

}

