using UnityEngine;
using System.Collections;

public class UIClickEventReceiver : MonoBehaviour {

	public void DisplaySuccessMessage(){
		WindowManager.Instance.SendSuccessMessage ("SUCCESS", "This is a success");
	}

	public void DisplayErrorMessage(){
		WindowManager.Instance.SendErrorMessage ("ERROR 404", "This is an error");
	}
}
