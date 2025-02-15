using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryItemPhysics : MonoBehaviour
{
    private Rigidbody2D rb;
    private int eyeBallLayer;
    //On Collision, stop moving and become part of the animal

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        eyeBallLayer = LayerMask.NameToLayer("EyeBalls");
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == eyeBallLayer)
        {
            Debug.Log("AccessoryCollision detected");

            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0f;

            rb.simulated = false;

            transform.SetParent(collision.transform);
        }
    }
}
