using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {


	public Transform groundCheck;
	public float jumpPower = 100;
	public LayerMask whatIsGround;

	private Rigidbody rb;
	private PlayerInput PI;
	private Vector3 jumpVector;
	private GameController GC;
	private bool doublejump;
	public Vector3 forwardforce;
	public Vector3 maxspeed;
	public Vector3 gravity;
	public Vector3 defaultspeed;



	public bool onGround = false;

	// Use this for initialization
	void Awake () {
		doublejump = true;
		rb = GetComponent<Rigidbody>();
		PI = GetComponent<PlayerInput>();
		jumpVector = new Vector3(0, jumpPower, 0);
		GC = GameObject.Find("_GAMECONTROLLER").GetComponent<GameController>();
		rb.AddForce (defaultspeed);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		onGround = Physics.Linecast(transform.position, groundCheck.transform.position, whatIsGround);
		rb.AddForce (gravity);

		if (onGround == true) {
			doublejump = true;

		} 


		if(PI.jump && onGround){
			rb.AddForce(jumpVector);
		}
		if (onGround == false && PI.jump && doublejump) {
			rb.AddForce(jumpVector);
			doublejump =false;
		
		}
		if (rb.velocity.x < maxspeed.x) {
			rb.AddForce (forwardforce);
		}



	}
}
