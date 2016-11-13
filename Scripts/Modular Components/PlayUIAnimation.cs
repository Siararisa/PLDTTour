using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlayUIAnimation : MonoBehaviour {
	public List<UIAnimationItem> uiItems;

	void Start(){
		if (GetComponent<Button> () != null) {
			Button myButton = GetComponent<Button> ();
			myButton.onClick.AddListener (() => {
				PlayAnimation();
			});
		}
	}

	void PlayAnimation(){
		for(int i = 0; i < uiItems.Count; i++){
		switch (uiItems[i].animationState) {
			case TransitionState.TransitionIn:
				StartCoroutine(PlayTransitionInAnimation (uiItems [i]));
				break;
			case TransitionState.TransitionOut:
				StartCoroutine(PlayTransitionOutAnimation (uiItems [i]));
				break;
			case TransitionState.Enable:
				uiItems [i].anim.transform.gameObject.SetActive (true);
				break;
			case TransitionState.Disable:
				uiItems [i].anim.transform.gameObject.SetActive (false);
				break;
			}
		}
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
