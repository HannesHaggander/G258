using UnityEngine;
using System.Collections;

public class SubMenuLoadLevel : MonoBehaviour {

	/**
	 * Used on all sub-levels to load a assigned level 
	 */
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
