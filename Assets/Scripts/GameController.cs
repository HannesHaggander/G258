using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private GameObject player;

	void Awake(){
		DontDestroyOnLoad(gameObject);
		player = GameObject.Find ("player");

	}

}
