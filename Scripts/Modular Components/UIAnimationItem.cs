using UnityEngine;
using System.Collections;


public enum TransitionState{TransitionIn, TransitionOut, Enable, Disable}
public enum EndObjectState{DisabledOnEnd, DoNothing}
public enum StartObjectState{EnableOnStart, DoNothing}

[RequireComponent(typeof(Animation))]
[System.Serializable]
public class UIAnimationItem {
	public Animation anim;
	public string animationName;//what animation will be played?
	public TransitionState animationState;//what transition will the animation play?
	public StartObjectState startState;//what will happen to object before animation plays?
	public EndObjectState endState;//what will happen to the object after animation ends?
}
