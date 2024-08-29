using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerParentController : MonoBehaviour
{
    private List<TimerController> timerControllers = new List<TimerController>();

    // Start is called before the first frame update
    void Start()
    {
        TimerController[] timerList = GetComponentsInChildren<TimerController>();

        foreach (var item in timerList)
        {
            timerControllers.Add(item);
        }
    }

    public void PauseAllTimers()
    {
        foreach (var timer in timerControllers)
        {
            timer.PauseTimer();
        }
    }

    public void ResetAllTimers()
    {
        foreach (var timer in timerControllers)
        {
            timer.ResetTimer();
        }
    }
}
