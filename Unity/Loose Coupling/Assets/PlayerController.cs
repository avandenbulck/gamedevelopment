using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

	// Update is called once per frame
	void Update () {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        transform.position += (Vector3.right * moveX * speed + Vector3.up * moveY * speed) * Time.deltaTime;
	}
}
