using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapPoint : MonoBehaviour
{
    public int id;
    public PointType snapPointType;

    public void SnapPointTriggered()
    {
        Debug.Log($"Snap point {id} has been triggered");

    }
}

public enum PointType
{
    Idle, Timed, Accessories
};
