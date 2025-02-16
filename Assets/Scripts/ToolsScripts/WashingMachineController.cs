using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashingMachineController : MonoBehaviour
{
    private bool isWashingMachineOn;
    private Animator animator;

    void Start()
    {
        isWashingMachineOn = false;
        animator = GetComponent<Animator>();
    }

    public void StartWashingMachine()
    {
        isWashingMachineOn = true;
        animator.SetBool("IsWashingMachineOn", true);
    }

    public void StopWashingMachine()
    {
        isWashingMachineOn = false;
        animator.SetBool("IsWashingMachineOn", false);
    }
}
