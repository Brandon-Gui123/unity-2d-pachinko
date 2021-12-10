using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int initialBalls;

    public int balls;
    public int score;

    public TextMeshProUGUI ballsCount;
    public TextMeshProUGUI scoreCount;

    private void Start()
    {
        SetBallsCount(initialBalls);
        SetScoreCount(score);
    }

    public void SetBallsCount(int value)
    {
        balls = value;
        ballsCount.text = $"Balls: {balls}";
    }

    public void SetScoreCount(int value)
    {
        score = value;
        scoreCount.text = $"Score: {score}";
    }
}
