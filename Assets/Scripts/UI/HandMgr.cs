using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class HandMgr : MonoBehaviour
{
	private static HandMgr _instance;
	public static HandMgr Instance => _instance;

	public GameObject cardPrefab;
	public Transform handContainer;

	[Header("Fan Layout Settings")]
	public float fanAngle = 30f;    // 每增加一张牌增加的角度，或者总角度
	public float radius = 600f;     // 这里的半径建议设置大一点（如600-1000）
	public float verticalOffset = 30f; // 弧度修正

	void Awake()
	{
		_instance = this;
	}

	// 核心：计算第 index 张牌在总数为 totalCount 时的位置和角度
	public CardPose GetCardTargetPose(int index, int totalCount)
	{
		// 1. 处理单张牌的特殊情况
		if (totalCount <= 1)
		{
			return new CardPose { position = Vector2.zero, rotation = Quaternion.identity };
		}

		// 2. 计算扇形分布
		// 这里的逻辑：让手牌关于中心轴对称
		float currentFanAngle = Mathf.Min(fanAngle * (totalCount - 1), 10f); // 限制最大总弧度，防止牌太多转一圈
		float startAngle = currentFanAngle / 2f;
		float angleStep = currentFanAngle / (totalCount - 1);

		float angle = startAngle - (index * angleStep);
		float radian = angle * Mathf.Deg2Rad;

		// 3. 计算坐标 (凹形圆弧)
		// 注意：如果你想让圆心在上面，y 的计算必须是基于半径的负向偏移
		float x = Mathf.Sin(radian) * radius;
		float y = -(radius - Mathf.Cos(radian) * radius); // 这样 angle=0 时 y=0

		// 4. 额外的垂直微调（让边缘的牌更低，形成更明显的凹形）
		float curveWeight = Mathf.Pow(Mathf.Abs(index - (totalCount - 1) / 2f) / ((totalCount - 1) / 2f), 2);
		y -= curveWeight * verticalOffset;

		return new CardPose
		{
			position = new Vector2(x, y),
			rotation = Quaternion.Euler(0, 0, -angle)
		};
	}

	public void RefreshLayout(int currentHandCount)
	{
		int childCount = handContainer.childCount;
		for (int i = 0; i < childCount; i++)
		{
			RectTransform rect = handContainer.GetChild(i) as RectTransform;
			// 使用我们计算出的“逻辑位置”
			CardPose target = GetCardTargetPose(i, currentHandCount);

			// 丝滑移动
			rect.DOKill(); // 防止动画冲突
			rect.DOAnchorPos(target.position, 0.4f).SetEase(Ease.OutBack);
			rect.DOLocalRotateQuaternion(target.rotation, 0.4f).SetEase(Ease.OutBack);
		}
	}

	public void AddCardToHandUI(CardData data)
	{
		GameObject newCard = Instantiate(cardPrefab, handContainer);
		// 新生成的牌可以从下方飞入
		RectTransform rect = newCard.GetComponent<RectTransform>();
		rect.anchoredPosition = new Vector2(0, -200);

		CardView view = newCard.GetComponent<CardView>();
		if (view != null) view.Init(data);
	}
}

public struct CardPose
{
	public Vector2 position;
	public Quaternion rotation;
}