using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandMgr : MonoBehaviour
{
	private static HandMgr _instance;
	public static HandMgr Instance { get { return _instance; }
		set {_instance = value; } 
	
	}
	public GameObject cardPrefab;
	public Transform handContainer;

	void Awake() {
		if (_instance != null && _instance != this)
		{
			Destroy(gameObject);
			return;
		}
		_instance = this;
	}

	public void AddCardToHandUI(CardData data) {
		//实例化预制体
		if (cardPrefab == null || handContainer == null) return;
		GameObject newCard = Instantiate(cardPrefab, handContainer);
		//调用CardView并获取初始值
		CardView view = newCard.GetComponent<CardView>();

		if (view != null)
		{
			view.Init(data);
		}
		else
		{
			Debug.LogError("预制体上缺少 CardView 组件！");
		}
		//可以增加飞入动画

	}
}