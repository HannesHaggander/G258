using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveAndLoad : MonoBehaviour {

	/**
	 * Saving progress in a .dat file for usage later on
	 */

	public string filePath = "";
	private LevelData data;

	/**
	 * saves to the /savedInfo.dat file if there is one otherwise it's created
	 * When the file is fetched it's serialized by a binaryFormatter for later
	 * use.
	 */
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

	/**
	 * opens the file and writes the score to the file then closes it again
	 * can be used in other scripts to save scores.
	 */
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

	/**
	 * To fetch data from our previously saved file we have to make the data readable.
	 * It still uses a BinaryFormatter where we deserialize the data in the save file
	 * and retrieves the data.
	 */
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

	/**
	 * Container for the saved data, variables can be added or removed as long as 
	 * theyre not used previously.
	 */
[System.Serializable]
class LevelData{
	//public int health;
	public string unfinishedLevel;
	public float HighScore = 0;

}