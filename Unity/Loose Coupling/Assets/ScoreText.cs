using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{

    public UnityEvent Clicked;
    public GameManager gameManager;

    private Text text;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        gameManager.OnScoreChanged += UpdateScore;
    }

    //void Update()
    //{
    //    text.text = "Score: " + gameManager.GetScore(); //Executed once every frame. Bad performance.
    //}

    void UpdateScore(int newScore)
    {
        text.text = "Score: " + newScore; // Only executed when score changes.
        Clicked.Invoke();
    }
}
