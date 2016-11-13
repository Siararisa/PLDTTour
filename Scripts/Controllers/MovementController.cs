using UnityEngine;
using System.Collections;

public class MovementController: MonoBehaviour {

	private Rigidbody myRb;
	public float distance = 40;
	bool isMoving;

	void Start(){
		//Screen.orientation = ScreenOrientation.LandscapeLeft;
		myRb = GetComponent<Rigidbody> ();
	}


	void Update(){
		if (!isMoving)
			return;
		myRb.AddForce(Camera.main.transform.forward * distance);
	}

	public void MoveForward(){
		isMoving = true;
	}

	public void StopMovement(){
		isMoving = false;
	}


}
