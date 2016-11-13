using UnityEngine;
using UnityEngine.UI;	
using System.Collections;

public class TextDisplayController : WindowItem {
	public Text phoneNumber;
	public Text txtMessage;

	public void SendTextMessage()
	{
		APIManager.instance.sendTextMessage (txtMessage.text, phoneNumber.text,
			(string message, bool success) => {
				if (success) {
					if (!string.IsNullOrEmpty (message))
						WindowManager.Instance.ErrorMessage ("Success", message);
				} else
					WindowManager.Instance.ErrorMessage ("ERROR", "Unknown Error Occured!");

			},
			(string message, bool error) => {
				if (error) {
					if (!string.IsNullOrEmpty (message))
						WindowManager.Instance.ErrorMessage ("ERROR", message);
				} else
					WindowManager.Instance.ErrorMessage ("ERROR", "Uknown Error Occured!");
			});
	}
}
