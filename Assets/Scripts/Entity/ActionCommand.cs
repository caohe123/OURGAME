using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCommand {
	public Entity source;
	public Entity target;
	public IEffect effect;
	public int value;

	public IEnumerator Process()
	{
		// 它会等待 Effect 的协程执行完（包含动画时间）再结束
		yield return effect.Execute(source, target, value);
	}

}
