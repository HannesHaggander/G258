using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	/**
	 * Used to move the player in different ways and providing the option to jump
	 */

	public Transform frontGroundCheck;
	public Transform backGroundCheck;

	public float jumpPower = 100;
	public float sPower= 1000;
	public LayerMask whatIsGround;



	private Rigidbody rb;
	private PlayerInput PI;
	private Vector3 jumpVector;
	private Vector3 springVector;
	//private GameController GC;
	private bool doublejump;
	private static bool sjump;

	public Vector3 forwardforce;
	public Vector3 maxspeed;
	public Vector3 gravity;
	public Vector3 defaultspeed;
	
	public bool doubleJumpingEnabled = true;
	public bool onGround = false;
	private bool frontCheck;
	private bool backCheck;

	// Use this for initialization
	/**
	 * Gets all the required components from the player object to modify.
	 * 
	 */
	void Awake () {
		doublejump = true;
		rb = GetComponent<Rigidbody>();
		PI = GetComponent<PlayerInput>();
		jumpVector = new Vector3(0, jumpPower, 0);
		springVector= new Vector3(0, sPower, 0);
		//GC = GameObject.Find("_GAMECONTROLLER").GetComponent<GameController>();
		
		rb.AddForce (defaultspeed);

	}
	
	// Update is called once per frame
	/**
	 * Moves the player object forwards 
	 * Checks if the player is on the defined ground with a linecast from the center of the 
	 * player to a given transform. If there's a ground inbetween the two transforms, the 
	 * player is on the ground and is anable to jump.
	 */

	void FixedUpdate () {
		frontCheck = Physics.Linecast(transform.position, frontGroundCheck.transform.position, whatIsGround);
		backCheck = Physics.Linecast(transform.position, backGroundCheck.transform.position, whatIsGround);
		onGround = frontCheck || backCheck ? true : false;



		if (sjump == true) {
			Vector3 temp = rb.velocity;
			temp.y= 0;
			rb.velocity = temp;
			rb.AddForce(springVector);
			sjump = false;

		}


		if (onGround == true) {
			doublejump = true;
			//rb.velocity.y = Vector3;

		} 

		//check jump input is trigged
		if(PI.jump && onGround){
			rb.AddForce(jumpVector);
		
		}

		//check double jump
		if (onGround == false && PI.jump && doublejump && doubleJumpingEnabled) {
			Vector3 temp = rb.velocity;
			temp.y= 0;
			rb.velocity = temp;
			rb.AddForce(jumpVector);
			doublejump =false;
		
		}

		//maxspeed limit
		if (rb.velocity.x < maxspeed.x) {
			rb.AddForce (forwardforce);

		}



	}

	//spring check
	public static void spring(){
		sjump = true;
	}
}
		
