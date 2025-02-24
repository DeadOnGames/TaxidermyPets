using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScoreDisplay : MonoBehaviour
{

    public TextMeshProUGUI station1ScoreText;
    public TextMeshProUGUI station2ScoreText;
    public TextMeshProUGUI station3ScoreText;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI gradeText;

    public void UpdateUIValues(string st1Score, string st2Score, string st3Score, string finalScore, string gradeScore)
    {
        station1ScoreText.text = st1Score;
        station2ScoreText.text = st2Score;
        station3ScoreText.text = st3Score;
        finalScoreText.text = finalScore;
        gradeText.text = gradeScore;
    }
}
