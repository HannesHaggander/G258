using UnityEngine;
using System.Collections;

public class LoadLevelButton : MonoBehaviour {

	public GameObject[] nodeLevels;

	private bool pressed = false;

	private MenuScrolling MS;
	private PlayerInput PI;

	void Start(){
		PI = GameObject.Find ("_GAMECONTROLLER").GetComponent<PlayerInput>();

	}

	void OnMouseOver(){
		if(PI.mouseOne){
			Debug.Log (gameObject.name + " button pressed");
			pressed = true;
			MS = GameObject.Find ("Pointer").GetComponent<MenuScrolling>();
			MS.currentFrame = 0;
			MS.SpawnSubNodes(transform, nodeLevels);
			MS.spawned = true;
		
		}
	}
}
