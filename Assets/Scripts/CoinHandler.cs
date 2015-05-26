using UnityEngine;
using System.Collections;

public class CoinHandler : MonoBehaviour {
	
	private CoinController coinController;

	void Start() {
		coinController = GameObject.Find ("CoinController").GetComponent<CoinController> ();
	}

	void OnTriggerEnter(Collider col){
		Debug.Log (col.name + " entered ");
		if(col.gameObject.name.Equals("Player") || col.gameObject.name.Equals("player")){
			Debug.Log ("Coin");
			Destroy(this.gameObject);

			//CoinController.increaseCoins();
			coinController.increaseCoins();
		}
	}
}
