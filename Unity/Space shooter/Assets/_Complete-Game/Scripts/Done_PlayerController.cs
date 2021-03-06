﻿using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Done_Boundary boundary;
    public GameObject beam;
    public float beamDuration;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	 
	private float nextFire;
    private float currentCharge;

    public UnityEvent onChargeChanged;
	
	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			GameObject boltObject = Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            Bolt bolt = boltObject.GetComponent<Bolt>();
            bolt.SetOnChargeUpAction(IncreaseCharge);

            GetComponent<AudioSource>().Play ();
		}
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;
		
		GetComponent<Rigidbody>().position = new Vector3
		(
			Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);
		
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}

    public void IncreaseCharge(float charge)
    {
        if(currentCharge < 100)
        {
            currentCharge += charge;
            onChargeChanged.Invoke();
            Debug.Log(charge);
        } else
        {
            beam.SetActive(true);
            StartCoroutine(ResetBeam());
        }
    }

    private IEnumerator ResetBeam()
    {
        yield return new WaitForSeconds(beamDuration);
        beam.SetActive(false);
        currentCharge = 0;
        onChargeChanged.Invoke();
    }

    public float getCurrentChargeValue()
    {
        return currentCharge;
    }
}
