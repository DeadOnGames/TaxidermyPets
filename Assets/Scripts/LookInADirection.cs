using System.Collections;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LookInADirection : MonoBehaviour
{
    public GameObject target;
    public bool IsFacingTarget {  get; set; }
    public float damping = 5;
    public int offsetAngle = 0;

    private Vector2 originalPosition;
    private Quaternion originalRotation;

    private void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    private void Update()
    {
        if (IsFacingTarget)
            FaceTarget();
    }

    public void FaceTarget()
    {
        Vector2 direction = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - offsetAngle;

        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * damping);
    }

    public void ReturnToOriginalPosition()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }
}
