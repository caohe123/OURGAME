using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//使用EffectsEntry整合value和effect，并执行effect
[System.Serializable]
public class EffectEntry
{
	[SerializeReference, SubclassSelector]
	public EffectBase effect;
	public int value;
}

[CreateAssetMenu(fileName = "NewCard", menuName = "Resources/CardGame/CardData")]
public class CardData : ScriptableObject {
	[Header("Card Data")]
	public string cardName;
	public int cost;
	public Sprite cardArt;
	[TextArea]public string textArea;

	[Header("Card State")]

	public List<EffectEntry> effectsEntries = new List<EffectEntry>();

	private void OnValidate()
	{
		if (string.IsNullOrEmpty(cardName))
		{
			cardName = name; // 自动将资源文件的名字赋值给 cardName 字段
		}
	}
}
