using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrawState : BaseState
{
	public PlayerDrawState(StateMgr mgr):base(mgr) { }
	internal protected override void Enter()
	{
		// 1. 获取玩家实体和卡牌管理器的引用
		var player = BattleMgr.Instance.PlayerEntity;
		var cardMgr = CardMgr.Instance;
		// 2. 计算最终抽牌数 (处理你提到的 Debuff 影响)
		int drawCount = player.GetFinalDarwCount();

		// 3. 开启抽牌协程
		owner.StartCoroutine(DrawSequence(drawCount, cardMgr));
	}

	private IEnumerator DrawSequence(int count, CardMgr cardMgr)
	{
		for (int i = 0; i < count; i++)
		{
			// 逻辑抽牌：改变数据层
			CardData drawnCard = cardMgr.DrawCard();

			if (drawnCard != null)
			{
				// 表现层触发：抛出事件让 UI 播放“发牌动画”
				// 你可以传入卡牌数据，让 UI 生成对应的卡牌物体
				//GameEvents.OnCardDrawnUI?.Invoke(drawnCard);
				HandMgr.Instance.AddCardToHandUI(drawnCard);
			}

			// 炫技点：控制发牌节奏，每张牌间隔 0.15s
			yield return new WaitForSeconds(0.15f);
		}

		// 4. 切换契机：所有牌发完后，进入玩家操作回合
		owner.SwitchState(new PlayerTurnState(owner));
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
		Debug.Log("Transitioning to PlayerTurnState");
	}

}
