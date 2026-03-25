using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectBase {
	//target是目标对象
	public abstract void Execute(Entity target,int value);

	public abstract void LogEffect(Entity target, int val);
}