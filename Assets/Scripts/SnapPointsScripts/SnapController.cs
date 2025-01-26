using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SnapController : MonoBehaviour
{
    public List<Transform> snapPoints;
    public List<Draggable> draggableObjects;
    public float snapRange = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Draggable draggable in draggableObjects)
        {
            draggable.dragStartedCallBack = OnDragStarted;
            draggable.dragEndedCallBack = OnDragEnded;
        }
    }

    public void OnDragStarted(Draggable draggable)
    {
        //Instead of releasing every snap point, only release the current triggered snap point 
        foreach (Transform point in snapPoints)
        {
            var snapPoint = point.GetComponent<SnapPoint>();

            if (snapPoint.isTriggered)
            {
                snapPoint.Release(draggable);
            }
        }
    }

    public void OnDragEnded(Draggable draggable)
    {
        float closestDistance = -1;
        Transform closestSnapPoint = null;

        foreach (Transform snapPoint in snapPoints)
        {
            //snapPoint.GetComponent<SnapPoint>().Release();
            float currentDistance = Vector2.Distance(draggable.transform.localPosition, snapPoint.localPosition);
            if (closestSnapPoint == null || currentDistance < closestDistance)
            {
                closestSnapPoint = snapPoint;
                closestDistance = currentDistance;
            }
        }

        //Snap the draggable to the snap point
        if (closestSnapPoint != null && closestDistance <= snapRange)
        {
            draggable.transform.localPosition = closestSnapPoint.localPosition;
            closestSnapPoint.gameObject.GetComponent<SnapPoint>().Snap(draggable);
        }
    }
}
