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

        Camera mainCamera = Camera.main;

        while (elapsedTime < duration)
        {
            Vector3 newPosition = Vector3.Lerp(startPosition, startPosition + new Vector3(10, 0, 0), elapsedTime / duration);

            Vector3 viewportPoint = mainCamera.WorldToViewportPoint(newPosition);
            if (viewportPoint.x < 0 || viewportPoint.x > 1 || viewportPoint.y < 0 || viewportPoint.y > 1)
            {
                objectToMove.transform.position = targetPosition;
                yield break;
            }

            objectToMove.transform.position = newPosition;
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        objectToMove.transform.position = targetPosition;
    }


}

