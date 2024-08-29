using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    private float time;
    private bool isTriggered;

    public Image timerProgress;
    public float doneTime = 3;
    public float maxTime = 6;


    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        timerProgress.color = Color.green;
    }

    // Update is called once per frame
    private void Update()
    {
        if (isTriggered)
        {
            if(time < maxTime)
            {
                if(time >= doneTime)
                {
                    timerProgress.color = Color.red;
                }
                time += Time.deltaTime;
                timerProgress.fillAmount = time / maxTime;
            }
        }
    }
    public void StartTimer()
    {
        isTriggered = true;
    }

    public void PauseTimer() 
    {
        isTriggered = false;
    }

    public void ResetTimer()
    {
        isTriggered= false;
        time = 0;
    }
}
