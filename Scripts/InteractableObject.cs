using UnityEngine;
using System.Collections;

public class InteractableObject : MonoBehaviour {

	public string windowToOpen;
	private WindowController win;

	public void OpenWindow(){
		WindowManager.Instance.FindWindow (windowToOpen);
		win = WindowManager.Instance.GetWindow;
		win.TransitionIn ();
		win.PlayAnim ();
	}
}
