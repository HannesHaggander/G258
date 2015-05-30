using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {

	//private static int coinCount;// = 0;
	private int coinCount;
	
	// Use this for initialization
	void Start () {
		coinCount = 0;
	}
	
	void OnGUI() {
		string coinText = "Score: " + coinCount;
		GUI.Box (new Rect(Screen.width-150, 20, 130, 20), coinText);
	}
	
	//public static void increaseCoins() {
	public void increaseCoins() {
		coinCount = coinCount+1;
	}
}
