using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupState : BaseState
{
	//public SetupState(StateMgr mgr) : base(mgr) { }
	internal protected override void Enter()
	{
		Debug.Log("Entering SetupState");
	}

	internal protected override void Update()
	{
		Debug.Log("Updating SetupState");
	}
	internal protected override void Exit()
	{
		Debug.Log("Exiting SetupState");
	}
	internal protected override void Transition()
	{
		Debug.Log("Transitioning to SetupState");
	}
}
