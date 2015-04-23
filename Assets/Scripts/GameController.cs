using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private GameObject player;
	public float levelStarted;
	public float levelFinished;
	public float score;

	public Transform cameraTarget;
	public string gameState;

	void Awake(){
		DontDestroyOnLoad(gameObject);
		player = GameObject.Find ("player");
		cameraTarget = GameObject.Find("CameraTarget").GetComponent<Transform>();
		gameState = "menu";

	}

	void Update(){

		switch (gameState){
		case "menu":

			break;

		case "playing":

			break;

		case "score":

			break;
		
		default:
			Debug.Log ("unknown game state");
			break;

		}
	}
}
