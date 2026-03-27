using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrawState : BaseState
{
	public PlayerDrawState(StateMgr mgr):base(mgr) { }
	internal protected override void Enter()
	{
		Debug.Log("Entering PlayerDrawState");
		var player = BattleMgr.Instance.PlayerEntity;
		var cardMgr = CardMgr.Instance;
	}

	internal protected override void Update()
	{
		Debug.Log("Updating PlayerDrawState");
	}
	internal protected override void Exit()
	{
		Debug.Log("Exiting PlayerDrawState");
	}

	internal protected override void Transition()
	{
		Debug.Log("Transitioning to PlayerDrawState");
	}

}
