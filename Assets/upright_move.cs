using UnityEngine;
using System.Collections;

public class upright_move : MonoBehaviour {

	public Vector3 speed;
	private Vector3 distance;
	public Vector3 maxdistance;
	// Use this for initialization
	void Start () {
		distance = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		distance += speed;
		transform.position += speed;
		if (System.Math .Abs (distance.x) >= maxdistance.x) {
			speed = -speed;
		}
		if (System.Math .Abs (distance.y) >= maxdistance.y) {
			speed = -speed;
		}
	}
}
