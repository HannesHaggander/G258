using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ReachBoundary: MonoBehaviour {

	public Text gameOverText;

	void Start ()
	{
		gameOverText.text = "";
	}


	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player")
		{
			//Debug.Log ("Reach boundary.");
			gameOverText.text = "Game Over";
			StartCoroutine(StartedQuest());
		}

	}

	IEnumerator StartedQuest()
	{
		yield return new WaitForSeconds(2);
		Application.LoadLevel(Application.loadedLevel);
	}
}
