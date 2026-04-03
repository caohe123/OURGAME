using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
	protected StateMgr owner;
	public BaseState(StateMgr owner) => this.owner = owner;
	internal protected virtual void Enter() {
        Debug.Log("Entering BaseState");
    }

	internal protected virtual void Update() {
        Debug.Log("Updating BaseState");
    }
	internal protected virtual void Exit() {
        Debug.Log("Exiting BaseState");
    }

	internal protected virtual void Transition() { 
        Debug.Log("Transitioning to BaseState");
    }
}
