using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    private float time;
    private bool isTriggered;

    //Timer segments
    private float quarterTime, halfTime, threeQuartersTime;

    public Image timerProgress;

    public float doneTime = 3;
    public float maxTime = 8;


    // Start is called before the first frame update
    void Start()
    {
        time = 0;

        CalculateTimerSegments();
        SetDoneTime(halfTime);

        timerProgress.color = Color.grey;
    }

    // Update is called once per frame
    private void Update()
    {
        if (isTriggered)
        {
            if(time < maxTime)
            {
                if(time >= quarterTime && time < halfTime)
                {
                    timerProgress.color = Color.green;
                }
                else if(time >= halfTime && time < threeQuartersTime)
                {
                    timerProgress.color = Color.yellow;
                }
                else if(time >= threeQuartersTime) 
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

    private void CalculateTimerSegments()
    {
        quarterTime = maxTime / 4;
        halfTime = maxTime / 2;
        threeQuartersTime = (maxTime / 4) * 3;
    }

    private void SetDoneTime(float timeSegment)
    {
        doneTime = timeSegment;
    }
}
