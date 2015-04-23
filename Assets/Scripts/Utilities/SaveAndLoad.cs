using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveAndLoad : MonoBehaviour {

	public string filePath = "";
	private LevelData data;

	public void Save(){
		string filePath = Application.persistentDataPath + "/savedInfo.dat";
		if(!File.Exists(filePath)){
			File.Create(filePath);
			
		} 
		
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Open(filePath, FileMode.Open);
		
		data = new LevelData();

		//saves the current level to the file
		data.unfinishedLevel = Application.loadedLevelName;
		
		bf.Serialize(file, data);
		file.Close();
		
	}

	public void SaveHighScore(float score){
		string filePath = Application.persistentDataPath + "/savedInfo.dat";
		if(!File.Exists(filePath)){
			Debug.Log ("Set high score failed, no file");
			return;

		}

		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Open(filePath, FileMode.Open);

		data.HighScore = score;
		bf.Serialize(file, data);
		file.Close();

	}
	
	public void Load(){
		if(File.Exists(Application.persistentDataPath + "/savedInfo.dat")){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/savedInfo.dat", FileMode.Open);
			LevelData data = bf.Deserialize(file) as LevelData;
			file.Close();
			
			Debug.Log ("loading level " + data.unfinishedLevel);
			Application.LoadLevel(data.unfinishedLevel);
			
		} else {
			Debug.Log ("file not found");
			
		}
	}

}

//container
[System.Serializable]
class LevelData{
	//public int health;
	public string unfinishedLevel;
	public float HighScore = 0;

}