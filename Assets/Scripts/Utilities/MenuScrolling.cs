using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScrolling : MonoBehaviour {

	/**
	 * Used to scroll through and choose all the 
	 * different levels in the MenuSelect screen.
	 */

	public GameObject[] levelButtons;
	public int currentFrame = 0;
	public float transSpeed = 0.4f;

	public bool moveRight = false,
			 	moveLeft = false; 


	public int xPadding = 5;
	public int yPadding = 5;
	private int loopPadding = 0;

	private Camera cam;
	private float smooth = 0.1f;

	private bool insubMenu = false;
	private GameObject[] givenSubNodes;
	public bool spawned = false;

	private PlayerInput PI;

	void Awake(){
		cam = GameObject.Find ("Main Camera").GetComponent<Camera>();
		PI = GetComponent<PlayerInput>();

		foreach(GameObject b in levelButtons){
			b.transform.position = new Vector3(xPadding * loopPadding, 0, 0);
			loopPadding++;

		}
	}

	/**
	 * Changes the camera focus depending on the current focused node and the
	 * input from the player
	 */
	void Update () {
		GameObject[] temp;
		if(!insubMenu){
			temp = levelButtons;

		} else {
			temp = givenSubNodes;
	
		}

		transform.position = temp[currentFrame].transform.position;	

		if(Input.GetKeyDown(KeyCode.A) || moveLeft){
			if(currentFrame > 0){
				currentFrame--;

			} else {
				if(insubMenu){
					insubMenu = false;
					spawned = false;
					DeleteSubNodes();
				}
			}
			moveLeft = false; 

		}
		
		if(Input.GetKeyDown(KeyCode.D) || moveRight){
			if(currentFrame < temp.Length -1){
				currentFrame++;

			}
			moveRight = false;

		}	

		if(spawned){
			cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, 
			                                         Quaternion.Euler(0,0,90),
			                                         smooth);
		} else {
			cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, 
			                                         Quaternion.Euler(0,0,0),
			                                         smooth);
		}
	}

	/**
	 * Used from other scripts to easily move the camera target and move
	 * through the array of levels.
	 */
	public void MoveRight(){
		moveRight = true;

	}

	public void MoveLeft(){
		moveLeft = true;

	}

	/**
	 * Spawns all the given sub-nodes from the editor. All of the levels are prefabs
	 * that are in the subNodes parameter. It's flexible to add a (almost) unlimited 
	 * amount of nodes in one array and spawn them all with correct padding and 
	 * rotation etc.
	 */
	public void SpawnSubNodes(Transform clickPos, GameObject[] subNodes){
		if(spawned){
			return;

		}

		Debug.Log (subNodes.Length);


		givenSubNodes = new GameObject[subNodes.Length];
		insubMenu = true;
		int current = 0;
		
		foreach(GameObject g in subNodes){
			givenSubNodes[current] = Instantiate(g, 
			            clickPos.position + new Vector3(0, yPadding + (yPadding*current), 0), 
			            Quaternion.Euler(0,0,90)) as GameObject;
			
			current++;
			
		}

	}

	public void DeleteSubNodes(){
		foreach(GameObject g in givenSubNodes){
			Destroy(g);

		}

	}
}
