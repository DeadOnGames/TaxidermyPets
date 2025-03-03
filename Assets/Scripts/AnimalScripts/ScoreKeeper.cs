using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private GameManager gameManager;

    private int totalPoints = 0;

    private float currentWashingTime = 0;
    private float currentStuffingTime = 0;

    private float perfectWashingTime = 4;
    private float perfectStuffingTime = 4;

    private float finalScore;
    public enum Grade
    {
        GRADE_S = 0,
        GRADE_A_PLUS = 1,
        GRADE_A = 2,    
        GRADE_B_PLUS = 3,
        GRADE_B = 4,
        GRADE_C_PLUS = 5,
        GRADE_C = 6,
        GRADE_D_PLUS = 7,
        GRADE_D = 8,
        GRADE_E = 9,
        GRADE_F = 10
    }

    private List<float> pointsPerStation = new List<float> {0, 0, 0}; //Stores the total points for each station

    public void Start()
    {
        gameManager = GameManager.Instance;
    }

    public void AddToWashingTime(float washingTime)
    {
        currentWashingTime += washingTime;
    }

    public void AddStuffingTime(float stuffingTime)
    {
        currentStuffingTime += stuffingTime;
    }

    public void CalculateTotalScore()
    {
        //Station 1

        //Bouns for all cut points
        pointsPerStation[0] = CalculateCutPointsScore();

        //Station 2
        float washingScore = CalculatePointsFromTimer(currentWashingTime, perfectWashingTime);
        float stuffingScore = CalculatePointsFromTimer(currentStuffingTime, perfectStuffingTime);
        float combinedScore = (washingScore * stuffingScore) / 100f;
        combinedScore = Mathf.Clamp(combinedScore, 0f, 100f);
        pointsPerStation[1] = combinedScore;

        //Station 3
        //Sew up

        //Correct eye
        //Eye placement
        //Accessories
        //Accessory placement

        float sumOfScores = 0;
        foreach (var point in pointsPerStation)
        {
            sumOfScores += point;
        }
        finalScore = sumOfScores / pointsPerStation.Count;

        //PrintScore();
        gameManager.scoreUIElements.UpdateUIValues(pointsPerStation[0].ToString("0.00") + "%",
            pointsPerStation[1].ToString("0.00") + "%",
             pointsPerStation[2].ToString("0.00") + "%",
                finalScore.ToString("0.00") + "%",
                CalculateGrade(finalScore).ToString());
    }

    private float CalculateCutPointsScore()
    {
        var cutPointController = GetComponentInChildren<CutPointController>();
        float totalNumCutPoints = (float)cutPointController.numOfCutPoints;
        float numCutPointsTriggered = (float)cutPointController.numOfCutPointsTriggered;

        float successfulCutPointsRatio = numCutPointsTriggered / totalNumCutPoints;
        return successfulCutPointsRatio * 100f;
    }

    private void PrintScore()
    {
        Debug.Log("Station 1 pts: " + pointsPerStation[0].ToString("0.00") + "%");
        Debug.Log("Station 2 pts: " + pointsPerStation[1].ToString("0.00") + "%");
        Debug.Log("Station 3 pts: " + pointsPerStation[2].ToString("0.00") + "%");
        Debug.Log("Total score pts: " + finalScore.ToString("0.00") + "%" + " Rank: " + CalculateGrade(finalScore));
    }

    public float CalculatePointsFromTimer(float actualTime, float idealTime, float maxTime = 8) //Max time defualts but should get value directly
    {
        if (actualTime <= 0f) return 0f; //Timer hasn't started

        if(actualTime >= maxTime) return 10f; //Timer at max time

        float timeDifference = Mathf.Abs(actualTime - idealTime);
        float falloffFactor = 1f;

        float score = 100f * Mathf.Exp(-falloffFactor * Mathf.Pow(timeDifference, 2));
        score = Mathf.Clamp(score, 0f, 100f);

        return score;
    }

    private Grade CalculateGrade(float finalScore)
    {
        if (finalScore == 100) return Grade.GRADE_S;
        if (finalScore >= 91 && finalScore <= 99) return Grade.GRADE_A_PLUS;
        if (finalScore >= 81 && finalScore <= 90) return Grade.GRADE_A;
        if (finalScore >= 71 && finalScore <= 80) return Grade.GRADE_B_PLUS;
        if (finalScore >= 61 && finalScore <= 70) return Grade.GRADE_B;
        if (finalScore >= 51 && finalScore <= 60) return Grade.GRADE_C_PLUS;
        if (finalScore >= 41 && finalScore <= 50) return Grade.GRADE_C;
        if (finalScore >= 31 && finalScore <= 40) return Grade.GRADE_D_PLUS;
        if (finalScore >= 21 && finalScore <= 30) return Grade.GRADE_D;
        if (finalScore >= 11 && finalScore <= 20) return Grade.GRADE_E;
        if (finalScore >= 0 && finalScore <= 10) return Grade.GRADE_F;

        return Grade.GRADE_F;
    }
}
