using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	/**
	 * Usage; All inputs are fetched from this script. If we want to change inputs 
	 * later there's no need to change every script individually and change every
	 * input in this script instead. 
	 */

	public bool jump;
	public bool mouseOne;
	public bool rightTouch = false; 
	public bool leftTouch  = false;
	public bool returnButtonTouch = false;
	public bool settingsButtonTouch = false;

	public bool inMenu = false;

	private Vector3 firstTouchPosStart, firstTouchPosEnd;

	private MenuScrolling MS; 

	/*
 	* In awake the MenuScrolling script is found and if we're in the menu
	*/
	void Awake(){
		if(Application.loadedLevelName.Equals("LevelSelect")){
			MS = GameObject.Find("Pointer").GetComponent<MenuScrolling>();
			inMenu = true;

		}
	}

	private bool move = false;
	private int dir = 0; 

	/**
	 * Used for touch movement in the menu
	 * 
	 */
	void FixedUpdate(){
		if(move){
			move = false;
			if(dir > 0){
				MS.MoveRight();

			} else if(dir < 0){
				MS.MoveLeft();

			}
			dir = 0;
		}

	}

	// Update is called once per frame
	/**
	 * Gets all the keys used for inputs, both button presses (for computer debugging)
	 * and the calculation for touches. How the player moved the first touch during 
	 * activation.  
	 */

	void Update () {
		jump = Input.GetKeyDown(KeyCode.Space);
		mouseOne = Input.GetMouseButtonDown(0);
		returnButtonTouch = Input.GetKeyDown(KeyCode.Escape);
		if (returnButtonTouch) {
			GameObject.Find("_MAIN").GetComponent<PauseScreen>().PauseMenu();
		}

		settingsButtonTouch = Input.GetKeyDown(KeyCode.Menu);

		if(settingsButtonTouch){
			Debug.Log ("menu button pressed, to level select");
			Application.LoadLevel("LevelSelect");

		}
		//settingsButtonTouch = Input.GetKeyDown(KeyCode.L);

		if(Input.touchCount > 0){
			Touch firstTouch = Input.GetTouch(0);
			jump = firstTouch.phase.Equals(TouchPhase.Began);

			if(inMenu){
				if(firstTouch.phase.Equals(TouchPhase.Began)){
					firstTouchPosStart = firstTouch.position;

				}

				if(firstTouch.phase.Equals(TouchPhase.Ended)){
					firstTouchPosEnd = firstTouch.position;

					if(firstTouchPosStart.x < firstTouchPosEnd.x){
						dir = -1;
						move = true;
						
					} else if(firstTouchPosStart.x > firstTouchPosEnd.x){
						dir = 1;
						move = true;
						
					}
				}
			}

		}
	}
}
