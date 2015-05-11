using UnityEngine;
using System.Collections;

public class movingground : MonoBehaviour {
	
	private Vector3 distance;
	public Vector3 speed;
	public Vector3 maxdistance;
	
	private bool hasSpeedX = false;
	private bool hasSpeedY = false;
	
	// Use this for initialization
	void Start () {
		distance= Vector3.zero;
	}
	
	// Update is called once per frame
	void FixedUpdate () {		
		checkSpeed ();
		if (hasSpeedX || hasSpeedY) {
			distance += speed;
			transform.position += speed;
		}
		// Change the moving direction if both x & y reach max distance
		if (System.Math.Abs (distance.x) >= maxdistance.x && System.Math.Abs (distance.y) >= maxdistance.y) {
			speed=-speed;
		}
	}

	/**
	 * Check if speed.x && speed.y are set
	 */
	void checkSpeed(){
		if (System.Math.Abs (speed.x) > 0 && maxdistance.x > 0) {
			hasSpeedX = true;
		}
		if (System.Math.Abs (speed.y) > 0 && maxdistance.y > 0) {
			hasSpeedY = true;
		}
	}
}
