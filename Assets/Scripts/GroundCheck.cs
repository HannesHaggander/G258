using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	private PlayerMovement pm;

	// Use this for initialization
	void Start () {
		/* gameObject is a local variable of type GameObject which is inherited from Component. 
		 * It allows one to access the instance of the GameObject to which this component is attached.
		 * Here gameObject = GameObject "groundCheck"
		 */
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
