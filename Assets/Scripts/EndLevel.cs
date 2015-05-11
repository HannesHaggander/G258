using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {

	private GameController GC;
	public string nextLevelName = "Default";

	void Awake(){
		GC = GameObject.Find ("_GAMECONTROLLER").GetComponent<GameController>();

	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.name.Equals("Player")){
			Debug.Log ("Level: " + Application.loadedLevelName + " completed!");
			Application.LoadLevel(nextLevelName);

		}

	}
}
