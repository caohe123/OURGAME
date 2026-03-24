using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnState : BaseState
{
	//public EnemyTurnState(StateMgr mgr) : base(mgr) { }
	internal protected override void Enter()
	{
		Debug.Log("Entering EnemyTurnState");
	}

	internal protected override void Update()
	{
		Debug.Log("Updating EnemyTurnState");
	}
	internal protected override void Exit()
	{
		Debug.Log("Exiting EnemyTurnState");
	}

	internal protected override void Transition()
	{
		Debug.Log("Transitioning to EnemyTurnState");
	}
}
