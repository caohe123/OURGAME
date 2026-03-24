using UnityEngine;

public class EntityView : MonoBehaviour
{
	private Entity _entity; // 用来存储被绑定的实体
	public void Bind(Entity entity)
	{
		// 1. 如果之前有绑定的，先解绑
		if (_entity != null) _entity.OnHpChanged -= UpdateHealthBar;

		// 2. 接收外部传进来的实体
		_entity = entity;

		// 3. 订阅新实体的事件
		if (_entity != null)
		{
			_entity.OnHpChanged += UpdateHealthBar;
		}
	}


	public void UpdateHealthBar(int current, int max)
	{
		Debug.Log($"{gameObject.name} 的血量更新为: {current}/{max}");
	}

	void OnDestroy()
	{
		if (_entity != null) _entity.OnHpChanged -= UpdateHealthBar;
	}
}
