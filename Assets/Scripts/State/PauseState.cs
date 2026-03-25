using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : BaseState {
	internal protected override void Enter()
	{
		Debug.Log("Entering PauseState");
	}

	internal protected override void Update()
	{
		Debug.Log("Updating PauseState");
	}
	internal protected override void Exit()
	{
		Debug.Log("Exiting PauseState");
	}

	internal protected override void Transition()
	{
		Debug.Log("Transitioning to PauseState");
	}
}
