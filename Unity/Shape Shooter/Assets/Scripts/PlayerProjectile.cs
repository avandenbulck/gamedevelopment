using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(MovingObject))]
public class PlayerProjectile : MonoBehaviour {

    public Vector2 velocity;
    public ProjectileType projectileType;

    private MovingObject movingObject;

    // Use this for initialization
    void Awake()
    {
        movingObject = GetComponent<MovingObject>();
    }

    void Start()
    {
        movingObject.SetVelocity(velocity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy.projectileType == projectileType)
                enemy.Die();
            Die();          
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
