using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoalSquare2 : MonoBehaviour {

    public UnityEvent OnPlayerEnter;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        OnPlayerEnter.Invoke();
    }
}
