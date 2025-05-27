using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update

    [ContextMenu("Walk to van")]
    void WalkIn()
    {
        animator.SetTrigger("WalkIn");
    }
}
