using System.Collections;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LookInADirection : MonoBehaviour
{
    public GameObject target;
    public bool isFacingTarget;
    public float damping = 5;
    public int offsetAngle = 0;

    private void Update()
    {
        if (isFacingTarget)
            FaceTarget();
    }

    public void FaceTarget()
    {
        Vector2 direction = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - offsetAngle;

        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * damping);
    }
}
