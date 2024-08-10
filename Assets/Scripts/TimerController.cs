using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    private float time;
    public Image timerProgress;
    public float maxTime;


    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(time < maxTime)
        {
            time += Time.deltaTime;
            timerProgress.fillAmount = time / maxTime;
        }
    }
}
