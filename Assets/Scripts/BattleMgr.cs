using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleMgr : MonoBehaviour
{
	private Entity _playerEntity; // 逻辑数据
	private EntityView _view;     // 表现组件
	public GameObject obj;//预制体！为空则不实例化！
	void Start()
	{
		StateMgr.Instance.OnStateChanged += HandleStateChanged;
		StateMgr.Instance.SwithchState(new SetupState());

		// 1. 获取同物体上的 EntityView 组件
		_view = GetComponent<EntityView>();

		// 2. 手动 new 一个实体（赋予灵魂）
		_playerEntity = new Entity(100, "Hero");

		// 3. 执行绑定：把数据塞给组件
		if (_view != null)
		{
			_view.Bind(_playerEntity);
		}

		// 测试一下：扣 10 点血，看看 Console 有没有打印
		_playerEntity.TakeDamage(10);
	}

	void Update()
	{
		//StateMgr.Instance.Tick();  
		//切换回合逻辑
		if(Input.GetMouseButtonDown(0))
			StateMgr.Instance.SwithchState(new PlayerDrawState());
		if(Input.GetMouseButtonDown(1))
			StateMgr.Instance.SwithchState(new PlayerTurnState());
		if (Input.GetKeyDown(KeyCode.Space))
			StateMgr.Instance.SwithchState(new EnemyTurnState());
	}
	void OnDestroy() { 
		StateMgr.Instance.OnStateChanged -= HandleStateChanged;
	}

	private void HandleStateChanged(BaseState state) {
		Debug.Log("State changed to " + state.GetType().Name);
	}
	//绑定预制体逻辑，直接在编辑器中拖动即可
	//public void SpawnMonster(GameObject prefab, Vector3 position)
	//{
	//	// 1. 创建逻辑对象 (纯 C#)
	//	Entity logic = new Entity(50,"player");

	//	// 2. 创建表现对象 (Unity GameObject)
	//	GameObject go = Object.Instantiate(prefab, position, Quaternion.identity);

	//	// 3. 关联两者
	//	EntityView view = go.GetComponent<EntityView>();
	//	view.Bind(logic);
	//}
}
