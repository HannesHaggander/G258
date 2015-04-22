﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {


	public Transform groundCheck;
	public float jumpPower = 100;
	public LayerMask whatIsGround;

	private Rigidbody rb;
	private PlayerInput PI;
	private Vector3 jumpVector;


	public bool onGround = false;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody>();
		PI = GetComponent<PlayerInput>();
		jumpVector = new Vector3(0, jumpPower, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(PI.jump && onGround){
			rb.AddForce(jumpVector);

		}

		onGround = Physics.Linecast(transform.position, groundCheck.transform.position, whatIsGround);
	}
}