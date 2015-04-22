using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		if(col.gameObject.name.Equals("player")){
			Debug.Log ("Level: " + Application.loadedLevelName + " completed!");
			Application.LoadLevel(Application.loadedLevel);
		}

	}
}
