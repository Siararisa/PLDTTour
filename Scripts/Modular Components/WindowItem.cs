using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public abstract class WindowItem : MonoBehaviour, IWindowItem {

	[SerializeField]private string _name;
	public string windowName { get{ return _name; } set{ _name = value; } }

	public UIAnimationItem anim;

	public void PlayAnim(){
		StartCoroutine (PlayTransitionInAnimation (anim));
	}

	protected void TransitionIn(){
		StartCoroutine (PlayTransitionInAnimation (anim));
	}

	void OnEnable()
	{
		StartCoroutine (PlayTransitionInAnimation (anim));
	}

	private IEnumerator PlayTransitionInAnimation(UIAnimationItem item){
		StartAnimationState (item);
		item.anim[item.animationName].speed = 1;
		item.anim [item.animationName].time = 0;
		item.anim.Play (item.animationName);
		while (item.anim.isPlaying) {
			yield return null;
		}
		EndAnimationState (item);
	}

	private IEnumerator PlayTransitionOutAnimation(UIAnimationItem item){
		StartAnimationState (item);
		item.anim[item.animationName].speed = -1;
		item.anim [item.animationName].time = item.anim [item.animationName].clip.length;
		item.anim.Play (item.animationName);
		while (item.anim.isPlaying) {
			yield return null;
		}
		EndAnimationState (item);
	}

	private void EndAnimationState(UIAnimationItem item){
		switch (item.endState) {
		case EndObjectState.DisabledOnEnd:
			item.anim.gameObject.SetActive (false);
			break;
		case EndObjectState.DoNothing:
			break;
		}
	}

	private void StartAnimationState(UIAnimationItem item){
		switch (item.startState) {
		case StartObjectState.EnableOnStart:
			item.anim.gameObject.SetActive (true);
			break;
		case StartObjectState.DoNothing:
			break;
		}
	}
}
