using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoalSquare : MonoBehaviour {

    public int goalValue;
    public GameManager gameManager;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.IncreaseScore(goalValue);
    }
}
