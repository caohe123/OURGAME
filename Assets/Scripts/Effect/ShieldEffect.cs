using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[AddTypeMenu("Effects/Shield")] // 配合插件可以自动分类
public class ShieldEffect: EffectBase {
	public override void Execute(Entity target, int value)
	{
		target.shield += value;
		LogEffect(target, value);
	}

	public override void LogEffect(Entity target, int val)
	{
		Debug.Log($"{target.entityName}触发了{target.shield}的护盾");
	}
}