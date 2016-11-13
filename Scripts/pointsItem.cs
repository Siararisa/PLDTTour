using UnityEngine;
using System.Collections;

public class pointsItem : MonoBehaviour {

	int randPoints;

	void OnEnable(){

	}

	void OnDisable(){

	}

	public void CollectPoints(){
		randPoints = Random.Range (1, 6);
		PointsManager.Instance.addPoints (randPoints);
		this.gameObject.SetActive (false);
		WindowManager.Instance.UpdateInfo ();
	}
}
