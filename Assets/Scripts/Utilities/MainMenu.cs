using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	/**
	 * Script used for displaying the main menu buttons and their functions
	 */

	public GameObject contButton;
	public Text startText;
	public Image fadeScreen;

	/**
	 * if there's data saved the continue button will show up and load the 
	 * players previous progress. Otherwise it will not show up.
	 */
	void Awake(){
		fadeScreen.gameObject.SetActive(true);
		fade (false);
		if(!File.Exists(Application.persistentDataPath + "/savedInfo.dat")){
			contButton.SetActive(false);

		} else {
			startText.text = "New Game";

		}

	}

	/**
	 * Functions for the start screen buttons
	 */
	public void StartButton(){
		string firstLevelName = "Tutorial";
		Debug.Log ("loading: " + firstLevelName);
		Application.LoadLevel("ha1");

	}

	public void ContinueButton(){
		Debug.Log ("pressed continue");

	}

	public void LevelSelectButton(){
		Debug.Log ("pressed level select");
		Application.LoadLevel ("LevelSelect");

	}

	public void HighScoreButton(){
		Debug.Log ("pressed high score");


	}

	float fadeAlpha;
	float fadeTime = 0.3f;

	void fade(bool inout){
		if(inout){
			fadeAlpha = 100;

		} else {
			fadeAlpha = 0;

		}	
		
		fadeScreen.CrossFadeAlpha(fadeAlpha, fadeTime, false);

	}
}
