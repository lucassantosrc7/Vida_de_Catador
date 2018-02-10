using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class saveLoad : MonoBehaviour {
 
	public static saveLoad instace;

	void Start(){
		instace = this;
	}
	// Use this for initialization
	public void Save (float tempo,float min, float seg, float posicaoX,float posicaoY) {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/PlayerInfo.data");

		PlayerInfo playerinfo = new PlayerInfo ();
		playerinfo.temp = tempo;
		playerinfo.min = min;
		playerinfo.seg = seg;
		playerinfo.posX = posicaoX;
		playerinfo.posY = posicaoY;

		bf.Serialize (file, playerinfo);
		file.Close ();
	}
	
	// Update is called once per frame
	public float[] load() {
		if(File.Exists(Application.persistentDataPath + "/PlayerInfo.data")){
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/PlayerInfo.data", FileMode.Open);

			PlayerInfo playerinfo = bf.Deserialize(file) as PlayerInfo;
			file.Close();

			float [] info = {playerinfo.temp,playerinfo.min,playerinfo.seg,playerinfo.posX,playerinfo.posY}; 


			return info;
		}

		return null;
	}
}

[System.Serializable]
class PlayerInfo{
	public float temp;
	public float min;
	public float seg;
	public float posX;
	public float posY;
}
