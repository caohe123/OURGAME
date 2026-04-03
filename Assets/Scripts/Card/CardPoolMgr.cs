using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPoolMgr {
	private static CardPoolMgr instance;
	public static CardPoolMgr Instance
	{
		get { return instance ?? (instance = new CardPoolMgr()); }
	}
	private Dictionary<string,Queue<GameObject>> cardPoolDict = new Dictionary<string, Queue<GameObject>>();

	public GameObject GetCard(string name) {
		GameObject card = null;

		if (cardPoolDict.ContainsKey(name) && cardPoolDict[name].Count > 0)
		{
			card = cardPoolDict[name].Dequeue();
			card.SetActive(true);
		}
		else {
			card = GameObject.Instantiate(Resources.Load<GameObject>(name));
			card.transform.SetParent(HandMgr.Instance.handContainer, false);
		}
		return card;
	}
	public void pushDict(GameObject card) {
		if (cardPoolDict.ContainsKey(card.name))
		{
			cardPoolDict[card.name].Enqueue(card);
			card.SetActive(false);
		}
		else {
			cardPoolDict.Add(card.name, new Queue<GameObject>());
			cardPoolDict[card.name].Enqueue((GameObject)card);
			card.SetActive(false);
		}
	}

	public void ClearPool() {
		cardPoolDict.Clear();
	}
}
