using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int totalPoints = 0;

    private float currentWashingTime = 0;
    private float currentStuffingTime = 0;

    public float perfectWashingTime = 0;
    public float perfectStuffingTime = 0;

    public void AddToWashingTime(float washingTime)
    {
        currentWashingTime += washingTime;
    }

    public void AddStuffingTime(float stuffingTime)
    {
        currentStuffingTime += stuffingTime;
    }

    public void CalculatePointsFromTimer(float actualTime, float idealTime)
    {
        
    }
}
