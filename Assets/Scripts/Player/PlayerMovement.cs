using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {


	public Transform frontGroundCheck;
	public Transform backGroundCheck;

	public float jumpPower = 100;
	public LayerMask whatIsGround;

	private Rigidbody rb;
	private PlayerInput PI;
	private Vector3 jumpVector;
	//private GameController GC;
	private bool doublejump;
	public Vector3 forwardforce;
	public Vector3 maxspeed;
	public Vector3 gravity;
	public Vector3 defaultspeed;
	
	public bool doubleJumpingEnabled = true;
	public bool onGround = false;
	private bool frontCheck;
	private bool backCheck;

	// Use this for initialization
	void Awake () {
		doublejump = true;
		rb = GetComponent<Rigidbody>();
		PI = GetComponent<PlayerInput>();
		jumpVector = new Vector3(0, jumpPower, 0);
		//GC = GameObject.Find("_GAMECONTROLLER").GetComponent<GameController>();

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
		frontCheck = Physics.Linecast(transform.position, frontGroundCheck.transform.position, whatIsGround);
		backCheck = Physics.Linecast(transform.position, backGroundCheck.transform.position, whatIsGround);
		onGround = frontCheck || backCheck ? true : false;


		if (onGround == true) {
			doublejump = true;

		} 

		if(PI.jump && onGround){
			rb.AddForce(jumpVector);
		
		}

		if (onGround == false && PI.jump && doublejump && doubleJumpingEnabled) {
			rb.AddForce(jumpVector);
			doublejump =false;
		
		}

		if (rb.velocity.x < maxspeed.x) {
			rb.AddForce (forwardforce);

		}



	}
}
