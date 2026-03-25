using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupState : BaseState
{
	internal protected override void Enter()
	{
		CardMgr.Instance.Init(); 
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
