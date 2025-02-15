using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public PolygonCollider2D EyeBallCollider;

    private void Start()
    {
        EyeBallCollider.enabled = false;
    }

    public void ActivateEyeBallCollider(bool isActive)
    {
        EyeBallCollider.enabled = isActive;
    }
}
