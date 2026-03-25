using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonEffect : EffectBase {
	public int turn;
	public PoisonEffect(int turn)
	{
		this.turn = turn;
	}

	public override void Execute(Entity target, int value)
	{
		if (turn > 0)
		{
			target.TakeDamage(value);
			LogEffect(target, value);
			turn--;
		}
	}

	public override void LogEffect(Entity target, int val)
	{
		Debug.Log($"{target.entityName}触发了{val}的中毒");
	}


}