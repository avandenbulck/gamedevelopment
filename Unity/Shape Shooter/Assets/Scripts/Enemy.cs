using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovingObject))]
public class Enemy : MonoBehaviour {

    public Vector2 velocity;
    public ProjectileType projectileType;

    private MovingObject movingObject;

	// Use this for initialization
	void Awake ()
    {
        movingObject = GetComponent<MovingObject>();
	}

     void Start()
    {
        movingObject.SetVelocity(velocity);
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
