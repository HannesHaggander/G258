﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ReachBoundary: MonoBehaviour {

	private PauseScreen ps;

	void Start(){
		ps = GameObject.Find ("main").GetComponent<PauseScreen> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player")
		{
			//Debug.Log ("Reach boundary.");
			//StartCoroutine(StartedQuest());
			ps.GameOverMenu();
		}

	}

	IEnumerator StartedQuest()
	{
		yield return new WaitForSeconds(2);
		Application.LoadLevel(Application.loadedLevel);
	}
}
