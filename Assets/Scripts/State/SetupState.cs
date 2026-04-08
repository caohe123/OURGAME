using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SetupState : BaseState
{
	public SetupState(StateMgr mgr) : base(mgr) { }

	internal protected override void Enter()
	{
		// 必须通过 owner 借用 MonoBehaviour 的能力来启动协程
		Debug.Log("Entering SetupState");
		owner.StartCoroutine(SetupProcess());
		CardMgr.Instance.Init();
	}

	private IEnumerator SetupProcess()
	{
		Debug.Log("正在读取卡牌库与实体数据...");

		// 1. 逻辑层初始化
		CardMgr.Instance.Init();

		// 2. 衔接 UI：通知 UI 播放“开场黑屏渐变”
		// 这里可以使用事件中心，不需要单例 UI
		//GameEvents.OnBattleStartLoading?.Invoke();

		// 3. 真正的“加载等待”
		yield return new WaitForSeconds(0.1f);

		// 4. 切换契机：加载完成，直接进入下一环节
		owner.SwitchState(new PlayerDrawState(owner));
	}
	internal override protected void Update()
	{
		Debug.Log("Updating SetupState");
	}
	internal override protected void Exit()
	{
		Debug.Log("Exiting SetupState");
	}

	internal override protected void Transition()
	{
		Debug.Log("Transitioning to PlayerDrawState");
	}
}