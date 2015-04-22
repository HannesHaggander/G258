using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	public bool jump;
	
	// Update is called once per frame
	void Update () {
		jump = Input.GetKeyDown(KeyCode.Space);

	}
}
