using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {

	private GameController GC;

	void Awake(){
		GC = GameObject.Find ("_GAMECONTROLLER").GetComponent<GameController>();

	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.name.Equals("player")){
			Debug.Log ("Level: " + Application.loadedLevelName + " completed!");
			Application.LoadLevel(Application.loadedLevel);

		}

	}
}
