using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    private float time;
    private bool isTriggered;

    public Image timerProgress;
    public float maxTime = 5;


    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (isTriggered)
        {
            if(time < maxTime)
            {
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
        
    }

    public void ResetTimer()
    {

    }
}
