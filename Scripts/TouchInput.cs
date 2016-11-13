using UnityEngine;
using System.Collections;

public class TouchInput : MonoBehaviour {

	void Update ()
	{
		#if !UNITY_EDITOR
		if (Input.touchCount > 0)
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch(0).position);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) 
			{
				if(hit.collider.tag == "Pickable")
				{
					hit.transform.GetComponent<InteractableObject> ().OpenWindow ();
				} 
			if(hit.collider.tag == "Points"){
			hit.transform.GetComponent<pointsItem>().CollectPoints();
			}
			}
		}
		#else
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) 
			{
				if(hit.collider.tag == "Pickable")
				{
					hit.transform.GetComponent<InteractableObject> ().OpenWindow ();
				} 
				if(hit.collider.tag == "Points"){
					hit.transform.GetComponent<pointsItem>().CollectPoints();
				}
			}
		}
		#endif
	}

	public void BackToScene(){
		UnityEngine.SceneManagement.SceneManager.LoadScene (0);
		Screen.orientation = ScreenOrientation.Portrait;
	}
}
