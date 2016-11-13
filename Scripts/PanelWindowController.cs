using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PanelWindowController : WindowController {
	public Text pointsCount, pointsCount2;
	void Awake(){
		Register ();
	}

	void OnEnable(){
		WindowManager.OnInfoUpdate += setPoints;
		WindowManager.Instance.UpdateInfo ();
	}

	void OnDisable(){
		WindowManager.OnInfoUpdate -= setPoints;
	}

	void setPoints(){
		pointsCount.text = PointsManager.Instance.getPoints().ToString();
		pointsCount2.text = PointsManager.Instance.getPoints().ToString();
	}


}
