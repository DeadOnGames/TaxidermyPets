using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    //Event delegate for finished dragging
    public delegate void DragEndedDelegate(Draggable draggableObject);
    public DragEndedDelegate dragEndedCallBack;

    private bool isDragged;
    private bool isDraggable = true;
    private Vector3 mouseDragStartPosition;
    private Vector3 objectDragStartPosition;

    public bool IsDraggable { set { isDraggable = value; } } 

    public virtual void OnMouseDown()
    {
        if (!isDraggable) return;

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
        
    }

    public void TeleportAnimal(Vector3 destination)
    {
        transform.localPosition = destination;
    }
}
