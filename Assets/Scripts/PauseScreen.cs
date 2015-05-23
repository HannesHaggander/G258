using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseScreen : MonoBehaviour {
	
	public bool paused = false;
	private RectTransform panel;
	private Canvas canvas;
	//public PlayerInput PI;

	void Awake() {
		//PI = GameObject.Find("Player").GetComponent<PlayerInput>();
		//panel = GetComponent <RectTransform> ();
		canvas = GameObject.Find("PauseCanvas").GetComponent<Canvas>();
		ShowPauseHideGameOverMenu ();
	}

	// Use this for initialization
	void Start () {
		canvas.enabled = false;
	}

	public void ShowPauseHideGameOverMenu() {
		canvas.transform.Find ("Pause").gameObject.SetActive (true);
		canvas.transform.Find ("GameOver").gameObject.SetActive (false);
	}

	public void GameOverMenu() {
		paused = true;
		canvas.enabled = true;
		canvas.transform.Find ("Pause").gameObject.SetActive (false);
		canvas.transform.Find ("GameOver").gameObject.SetActive (true);
		Time.timeScale = 0;
	}

	public void PauseMenu () {
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

	public void Quit () {
		Application.Quit ();
	}
}
