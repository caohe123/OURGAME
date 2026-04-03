using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardView : MonoBehaviour{
	[Header("UI Refenrence")]
	[SerializeField] private TextMeshProUGUI nameText;
	[SerializeField] private TextMeshProUGUI costText;
	[SerializeField] private TextMeshProUGUI descText;
	[SerializeField] private Image artworkImage;
	[SerializeField] private Image borderGlow; // 预留给发光效果

	private CardData currentData;

	public void Init(CardData data)
	{
		if (data == null) return;
		currentData = data;

		//建立于出牌者的联系

		UpdataUI();
	}
	public void UpdataUI() {
		if (currentData == null) return;
		nameText.text = currentData.name;
		costText.text = currentData.cost.ToString();

		// 如果你的 CardData 里有动态生成的描述（比如根据等级变化数值）
		// 可以在这里做逻辑处理，目前先直接赋值

		descText.text = currentData.textArea.ToString();

		if (currentData.cardArt != null)
		{
			artworkImage.sprite = currentData.cardArt;
		}

		// 默认隐藏发光效果
		if (borderGlow != null) borderGlow.enabled = false;
	}
}
