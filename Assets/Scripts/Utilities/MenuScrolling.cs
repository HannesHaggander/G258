using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScrolling : MonoBehaviour {

	public GameObject[] levelButtons;
	public int currentFrame = 0;
	public float transSpeed = 0.4f;

	public int xPadding = 5;
	public int yPadding = 5;
	private int loopPadding = 0;

	private Camera cam;
	private float smooth = 0.1f;

	private bool insubMenu = false;
	private GameObject[] givenSubNodes;
	public bool spawned = false;

	void Awake(){
		cam = GameObject.Find ("Main Camera").GetComponent<Camera>();

		foreach(GameObject b in levelButtons){
			b.transform.position = new Vector3(xPadding * loopPadding, 0, 0);
			loopPadding++;

		}
	}

	// Update is called once per frame
	void Update () {
		GameObject[] temp;
		if(!insubMenu){
			temp = levelButtons;

		} else {
			temp = givenSubNodes;
	
		}

		transform.position = temp[currentFrame].transform.position;


		if(Input.GetKeyDown(KeyCode.A)){
			if(currentFrame > 0){
				currentFrame--;

			} else {
				if(insubMenu){
					insubMenu = false;
					spawned = false;
					DeleteSubNodes();

				}
			}
		}

		if(Input.GetKeyDown(KeyCode.D)){
			if(currentFrame < temp.Length -1){
				currentFrame++;

			}
		}	

		if(spawned){
			cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, 
			                                         Quaternion.Euler(0,0,90),
			                                         smooth);
		} else {
			cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, 
			                                         Quaternion.Euler(0,0,0),
			                                         smooth);

		}
	}



	public void SpawnSubNodes(Transform clickPos, GameObject[] subNodes){
		if(spawned){
			return;

		}

		givenSubNodes = new GameObject[subNodes.Length];
		insubMenu = true;
		int current = 0;
		
		foreach(GameObject g in subNodes){
			givenSubNodes[current] = Instantiate(g, 
			            clickPos.position + new Vector3(0,(yPadding*current), 0), 
			            Quaternion.Euler(0,0,90)) as GameObject;
			
			current++;
			
		}

	}

	public void DeleteSubNodes(){
		foreach(GameObject g in givenSubNodes){
			Destroy(g);

		}

	}
}
