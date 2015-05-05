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
	
	public bool doubleJumpingEnabled = true;
	public bool onGround = false;

	// Use this for initialization
	void Awake () {
		doublejump = true;
		rb = GetComponent<Rigidbody>();
		PI = GetComponent<PlayerInput>();
		jumpVector = new Vector3(0, jumpPower, 0);
		GC = GameObject.Find("_GAMECONTROLLER").GetComponent<GameController>();

		/**
		 * OK, so. I would not recommend using this as our speed.  
		 * I would instead add force as we go and have a maximum
		 * speed restriction so that we can have longer levels 
		 * and still keep up with speed. Having a addforce in
		 * Awake is not the way to go.
		 * 
		 * Also, in the editor the default speed is 2000 and 
		 * jump power at 5000 at the moment. This is WAY to high, 
		 * it should be set to about between 5-10 depending on the
		 * prefered speed. 
		 * I get why the value is so high when you add it in Awake, 
		 * otherwise nothing would happen. Please reconsider.
		 * 
		 */
		rb.AddForce (defaultspeed);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		onGround = Physics.Linecast(transform.position, groundCheck.transform.position, whatIsGround);
		/**
		 * Im not sure what you want to do with the rb.addforce(gravity)
		 * you dont need to add the gravity because its used by default.
		 * By doing this we have 2 times the gravity, and it's not needed
		 * If you want a higher gravity setting please increase the gravity
		 * in the editor instead. Found under 
		 * 
		 * Edit -> Project Settings -> Physics 
		 * 
		 * then change the y value from the default -9.81 to whatever value
		 * you want to have. I've found that 20-25 is a sweetspot for 2d-games
		 * 
		 */
		rb.AddForce (gravity);


		/**
		 * Personal thought. This is ok for when we only want double jump
		 * but what if we suddenly want to have three jumps or more. We 
		 * could instead use a variable and decrease it when we press the jump
		 * button and if the variable is above 0 we would be able to jump again
		 * 
		 * nothing major, but we're limiting us to only having double jump this 
		 * way. 
		 */
		if (onGround == true) {
			doublejump = true;

		} 

		if(PI.jump && onGround){
			rb.AddForce(jumpVector);
		
		}

		/*
		 * minor issue, do we need to check onGround when jumping? shouldn't we be
		 * able to use the doublejump even though we're on the ground?
		 */

		// DOUBLE JUMPING
		if (onGround == false && PI.jump && doublejump && doubleJumpingEnabled) {
			rb.AddForce(jumpVector);
			doublejump =false;
		
		}

		/**
		 * this is how you add force, good job.  
		 * 
		 */
		if (rb.velocity.x < maxspeed.x) {
			rb.AddForce (forwardforce);

		}



	}
}
