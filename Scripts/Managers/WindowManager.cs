using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class WindowManager : Singleton<WindowManager> {

	public List<WindowController> windows = new List<WindowController> ();

	public delegate void messageDisplay(string headerString, string messageString);
	public static event messageDisplay OnSuccess;
	public static event messageDisplay OnError;

	public delegate void infoUpdate ();
	public static event infoUpdate OnInfoUpdate;

	public void UpdateInfo(){
		if (OnInfoUpdate != null)
			OnInfoUpdate ();
	}

	public void RegisterWindow(WindowController window){
		windows.Add (window);
	}

	public void UnRegisterWindow(WindowController window){
		windows.Remove (window);
	}

	public void SendSuccessMessage(string headerString, string messageString){
		if (OnSuccess != null) {
			OnSuccess (headerString, messageString);
		}
	}

	public void SendErrorMessage(string headerString, string messageString){
		if (OnError != null) {
			OnError (headerString, messageString);
		}
	}

	private WindowController window;
	public WindowController FindWindow(string windowName){
		Debug.LogError (windows.Count);
		for (int i = 0; i < windows.Count; i++) {
			if (windows [i].windowName == windowName) {
				Debug.Log (windowName);
				window = windows [i];
				return windows [i];
			}
		}
		Debug.Log ("none");
		return null;
	}

	public WindowController GetWindow{ get { return window; } }

	[SerializeField] MessageDisplayWindowController msgDisp =  new MessageDisplayWindowController();

	public void ErrorMessage(string header, string message)
	{
		msgDisp.txt_headerString.text = header;
		msgDisp.txt_messageString.text = message;

		msgDisp.gameObject.SetActive (true);
	}
}
