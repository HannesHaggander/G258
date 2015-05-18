using UnityEngine;
using System.Collections;

public class LoadLevelButton : MonoBehaviour {

	/**
	 * Used for the sub-level container buttons 
	 */

	public GameObject[] nodeLevels;

	private MenuScrolling MS;
	private PlayerInput PI;

	void Start(){
		PI = GameObject.Find ("PlayerInput").GetComponent<PlayerInput>();

	}

	/**
	 * if the main node is pressed by either touch or mouse input the given sub-levels
	 * are displayed from the SpawnNodes script from the Pointer object in the scene.
	 */
	void OnMouseOver(){
		if(PI.mouseOne){
			Debug.Log (gameObject.name + " button pressed");
			MS = GameObject.Find ("Pointer").GetComponent<MenuScrolling>();
			MS.currentFrame = 0;
			MS.SpawnSubNodes(transform, nodeLevels);
			MS.spawned = true;
		
		}
	}
}
