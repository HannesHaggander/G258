using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	public bool jump;
	public bool mouseOne;
	
	// Update is called once per frame
	void Update () {
		jump = Input.GetKeyDown(KeyCode.Space);
		mouseOne = Input.GetMouseButtonDown(0);

		if(Input.touchCount > 0){
			jump = Input.GetTouch(0).phase.Equals(TouchPhase.Began);
		
		}
	}
}
