using UnityEngine;
using System.Collections;

public class SubMenuLoadLevel : MonoBehaviour {

	private PlayerInput PI;
	public string loadlevelName = "Default";

	void Start(){
		PI = GameObject.Find ("PlayerInput").GetComponent<PlayerInput>();

	}

	void OnMouseOver(){
		if(PI.mouseOne){
			Application.LoadLevel(loadlevelName);

		}
	}
}
