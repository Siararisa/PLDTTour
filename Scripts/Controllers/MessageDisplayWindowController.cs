using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MessageDisplayWindowController :  WindowItem{
	public Text txt_headerString;
	public Text txt_messageString;

	void OnEnable(){
		WindowManager.OnSuccess += DisplayMessage;
		WindowManager.OnError += DisplayMessage;
	}

	void OnDisable(){
		WindowManager.OnSuccess -= DisplayMessage;
		WindowManager.OnError -= DisplayMessage;
	}

	private void DisplayMessage(string headerString, string messageString){
		TransitionIn ();
		txt_headerString.text = headerString;
		txt_messageString.text = messageString;
	}
}
