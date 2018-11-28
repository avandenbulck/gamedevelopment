using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    public void SetVelocity(Vector2 velocity)
    {
        rb.velocity = velocity;
    }
}
