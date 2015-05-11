﻿using UnityEngine;
using System.Collections;

public class PauseScreen : MonoBehaviour {
	
	public bool paused = false;
	private RectTransform panel;
	private Canvas canvas;
	public PlayerInput PI;

	void Awake() {
		PI = GameObject.Find("Player").GetComponent<PlayerInput>();
		//panel = GetComponent <RectTransform> ();
		canvas = GameObject.Find("PauseCanvas").GetComponent<Canvas>();
	}

	// Use this for initialization
	void Start () {
		canvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (PI.returnButtonTouch) {
			if(paused) {
				paused = false;
				canvas.enabled = false;
				Time.timeScale = 1;
			} else {
				paused = true;
				canvas.enabled = true;
				Time.timeScale = 0;
			}
		}
	}

	public void ResumeGame () {
		paused = false;
		canvas.enabled = false;
		Time.timeScale = 1;
	}

	public void RestartLevel () {
		Time.timeScale = 1;
		Application.LoadLevel(Application.loadedLevel);
	}

	public void ExitToMainmenu () {
		Time.timeScale = 1;
		Application.LoadLevel("MainMenu");
	}
}
