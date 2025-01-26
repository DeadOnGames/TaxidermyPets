using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Draggable : MonoBehaviour
{
    //Event delegate for start dragging
    public delegate void DragStartedDelegate(Draggable draggableObject);
    public DragStartedDelegate dragStartedCallBack;

    // UnityEvent for drag start
    [Serializable]
    public class DragStartEvent : UnityEvent<Draggable> { }
    public DragStartEvent OnDragStart;

    //Event delegate for finished dragging
    public delegate void DragEndedDelegate(Draggable draggableObject);
    public DragEndedDelegate dragEndedCallBack;

    // UnityEvent for drag end
    [Serializable]
    public class DragEndEvent : UnityEvent<Draggable> { }
    public DragEndEvent OnDragEnd;

    private bool isDragged;
    private bool isDraggable = true;
    private Vector3 mouseDragStartPosition;
    private Vector3 objectDragStartPosition;

    public bool IsDraggable { set { isDraggable = value; } } 

    public virtual void OnMouseDown()
    {
        if (!isDraggable) return;

        try
        {
            dragStartedCallBack(this);
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e.Message);
        }

        OnDragStart?.Invoke(this);

        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        objectDragStartPosition = transform.localPosition;
    }

    private void OnMouseDrag()
    {
        if (!isDraggable) return;

        if (isDragged)
        {
            transform.localPosition = objectDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
        }
    }
    public virtual void OnMouseUp() 
    {
        if (!isDraggable) return;

        isDragged = false;
        try
        {
            dragEndedCallBack(this);
        } catch (NullReferenceException e)
        {
            Debug.Log(e.Message);
        }
        OnDragEnd?.Invoke(this);
    }

    public void TeleportAnimal(Vector3 destination)
    {
        transform.localPosition = destination;
    }
}
