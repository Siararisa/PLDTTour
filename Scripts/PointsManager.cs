using UnityEngine;
using System.Collections;

public class PointsManager : Singleton<PointsManager> {

	private int points;
	void Awake(){
		points = getPoints ();
	}
	public void addPoints(int value){
		points += value;
		PlayerPrefs.SetInt ("pointValue", points);
		SavePoints ();
	}

	public int getPoints(){
		Debug.Log (PlayerPrefs.GetInt ("pointValue"));
		return PlayerPrefs.GetInt("pointValue", 0);
	}
		
	public void SavePoints(){
		PlayerPrefs.Save ();
	}
}
