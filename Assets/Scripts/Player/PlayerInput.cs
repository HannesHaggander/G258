using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	public bool jump;
	public bool mouseOne;
	public bool rightTouch = false; 
	public bool leftTouch  = false;

	public bool inMenu = false;

	private Vector3 firstTouchPosStart, firstTouchPosEnd;

	private MenuScrolling MS; 

	void Awake(){
		if(Application.loadedLevelName.Equals("LevelSelect")){
			MS = GameObject.Find("Pointer").GetComponent<MenuScrolling>();
			inMenu = true;

		}
	}

	// Update is called once per frame
	void Update () {
		jump = Input.GetKeyDown(KeyCode.Space);
		mouseOne = Input.GetMouseButtonDown(0);

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
						MS.MoveLeft();
						
					} else if(firstTouchPosStart.x > firstTouchPosEnd.x){
						MS.MoveRight();
						
					}
				}
			}

		}
	}
}
