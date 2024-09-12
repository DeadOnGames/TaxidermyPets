using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class SnapPoint : MonoBehaviour
{
    public int id;
    public bool isTriggered;

    public virtual void Snap(Draggable animal)
    {
        isTriggered = true;
        Debug.Log($"Snap point {id} has been triggered");
    }

    public virtual void Release()
    {
        if (isTriggered) isTriggered = false;
    }
}
