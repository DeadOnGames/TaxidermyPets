using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltController : MonoBehaviour
{
    //isConveyorBeltTriggered
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void TriggerConveyorBelt(bool isOn)
    {
        animator.SetBool("isConveyorBeltTriggered", isOn);
    }
}
