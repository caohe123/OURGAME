using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMgr
{
	private static CardMgr _instance;
	public static CardMgr Instance {
		get {return _instance?? (_instance = new CardMgr()); }
	}
	//存储所有资源文件夹加载的原始数据
	private Dictionary<string, CardData> _allCards = new Dictionary<string, CardData>();
	//抽牌堆、手牌堆、弃牌堆
	public List<CardData> drawPile = new List<CardData>();
	public List<CardData> handPile = new List<CardData>();
	public List<CardData> discardPile = new List<CardData>();

	public void Init()
	{
		// 实际开发中建议使用 Addressables 或 Resources.LoadAll 加载
		CardData[] assets = Resources.LoadAll<CardData>("CardGame/CardData");
		if (assets == null || assets.Length == 0)
		{
			Debug.LogError("路径 Card 下未找到任何 CardData 资源！请检查 Resources 文件夹结构。");
			return;
		}
		foreach (var card in assets)
		{
			_allCards.Add(card.cardName, card);
		}
		//drawPile.Add(assets[0]);
		//handPile.Add(assets[0]);
	}
	//Fisher-Yates Shuffles洗牌算法
	public void Shuffle() {
		int n = drawPile.Count;
		while (n > 1)
		{
			n--;
			int k = UnityEngine.Random.Range(0, n + 1);
			CardData value = drawPile[k];
			drawPile[k] = drawPile[n];
			drawPile[n] = value;
		}
	}
	//出牌，需要实体接受也需要牌
	public void PlayCard(Entity entity,CardData card)
	{
		for (int i = 0; i < card.effectsEntries.Count; i++) {
			card.effectsEntries[i].effect.Execute(entity,card.effectsEntries[i].value);
		}
		//discardPile.Add(card);
		//handPile.Remove(card);
	}
}
