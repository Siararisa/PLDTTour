using UnityEngine;
using System.Collections;

public class testgyro : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Rotate ((Input.gyro.rotationRateUnbiased.x < 60 && Input.gyro.rotationRateUnbiased.x > -60) ?
			-Input.gyro.rotationRateUnbiased.x * 2.0f : 0, -Input.gyro.rotationRateUnbiased.y * 2.0f, 0);
			
	}
}
