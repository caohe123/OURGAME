using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[AddTypeMenu("Effects/Damage")] // 配合插件可以自动分类
public class DamageEffect : EffectBase
{
	public override void Execute(Entity target, int value) { 
		target.TakeDamage(value);
		LogEffect(target, value);
	}
	public override void LogEffect(Entity target, int val)
	{
		Debug.Log($"{target.entityName}触发了{val}的伤害");
	}
}
