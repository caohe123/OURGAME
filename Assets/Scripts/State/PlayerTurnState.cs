using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnState : BaseState
{
	public PlayerTurnState(StateMgr mgr) : base(mgr) { }
	internal protected override void Enter()
	{
		Debug.Log("Entering PlayerTurnState");

	}

	internal protected override void Update()
	{
		Debug.Log("Updating PlayerTurnState");
	}
	internal protected override void Exit()
	{
		Debug.Log("Exiting PlayerTurnState");
	}

	internal protected override void Transition()
	{
		Debug.Log("Transitioning to PlayerDrawState");
	}
}
