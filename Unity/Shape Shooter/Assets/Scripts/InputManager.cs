using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public PlayerController player;
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ShootCircle();
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ShootSquare();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ShootTriangle();
        }
    }

    public void ShootCircle()
    {
        player.Shoot(ProjectileType.Circle);
    }

    public void ShootSquare()
    {
        player.Shoot(ProjectileType.Square);
    }

    public void ShootTriangle()
    {
        player.Shoot(ProjectileType.Triangle);
    }
}
