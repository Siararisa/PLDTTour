using UnityEngine;
using System.Collections;

[System.Serializable]
public abstract class WindowController : WindowItem {
	public bool isEnabledOnStart;

	void OnEnable()
	{
		
	}

	void OnDisable()
	{
		if (WindowManager.Instance.windows.Count > 4) TransitionOut ();
	}

	public void TransitionIn(){
		this.gameObject.SetActive (true);
	}

	public void TransitionOut(){
		WindowManager.Instance.UnRegisterWindow (this);
		this.gameObject.SetActive (false);
	}
	public void Register(){
		WindowManager.Instance.RegisterWindow (this);
		this.gameObject.SetActive (isEnabledOnStart);
	}



}
