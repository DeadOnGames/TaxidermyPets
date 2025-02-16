using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public abstract class SnapPoint : MonoBehaviour
{
    public int id;
    public bool isTriggered;

    public UnityEvent onSnapPointTriggered;
    public UnityEvent onSnapPointExited;

    public virtual void Snap(Draggable animal)
    {
        onSnapPointTriggered.Invoke();
        isTriggered = true;
        Debug.Log($"Snap point {id} has been triggered");
    }

    public virtual void Release(Draggable objectToSnap)
    {
        onSnapPointExited.Invoke();
        if (isTriggered) isTriggered = false;
    }
}
