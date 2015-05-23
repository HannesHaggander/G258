using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	private PlayerMovement pm;

	// Use this for initialization
	void Start () {
		pm = gameObject.GetComponentInParent<PlayerMovement> ();
	}
	
	void OnTriggerEnter(Collider other){
		if (other.gameObject.layer == 8) {
			pm.onGround = true;
		}
	}

	void OnTriggerStay(Collider other){
		if (other.gameObject.layer == 8) {
			pm.onGround = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.layer == 8) {
			pm.onGround = false;
		}
	}
}
