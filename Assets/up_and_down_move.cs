using UnityEngine;
using System.Collections;

public class up_and_down_move : MonoBehaviour {

	public Vector3 speed;
	private Vector3 distance;
	public Vector3 maxdistance;
	// Use this for initialization
	void Start () {
		distance = Vector3.zero;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		distance += speed;
		transform.position += speed;
		if (System.Math .Abs (distance.y) >= maxdistance.y) {
			speed = -speed;
		}
	}
}
