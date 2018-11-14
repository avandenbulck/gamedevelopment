using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public event Action<int> OnScoreChanged = delegate { };

    [SerializeField]
    private int score;

    public float GetScore()
    {
        return score;
    }

    public void SetScore(int score)
    {
        this.score = score;
        OnScoreChanged(score);
    }

    public void IncreaseScore(int amount)
    {
        int newScore = score + amount;
        SetScore(newScore);
    }

    public void ResetScore()
    {
        SetScore(0);
    }
}
