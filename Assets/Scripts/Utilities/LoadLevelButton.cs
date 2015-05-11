using UnityEngine;
using System.Collections;

public class LoadLevelButton : MonoBehaviour {

	public GameObject[] nodeLevels;

	private MenuScrolling MS;
	private PlayerInput PI;

	void Start(){
		PI = GameObject.Find ("PlayerInput").GetComponent<PlayerInput>();

	}

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
