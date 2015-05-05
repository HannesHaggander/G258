using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public GameObject contButton;
	public Text startText;
	public Image fadeScreen;


	void Awake(){
		fadeScreen.gameObject.SetActive(true);
		fade (false);
		if(!File.Exists(Application.persistentDataPath + "/savedInfo.dat")){
			contButton.SetActive(false);

		} else {
			startText.text = "New Game";

		}

	}

	public void StartButton(){
		string firstLevelName = "Tutorial";
		Debug.Log ("loading: " + firstLevelName);
		Application.LoadLevel("test");

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
