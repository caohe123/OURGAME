using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMgr//状态管理器
{
	private static StateMgr _instance;
	public static StateMgr Instance {
		get {
			return _instance?? (_instance = new StateMgr());
		}
	}
	private MonoBehaviour _driver;
	//目前的状态
	private BaseState _currentState;
	//当状态改变时通知外部
	public event Action<BaseState> OnStateChanged;

	public void Init(MonoBehaviour driver) {
		_driver = driver;
	}

	public void Tick() => _currentState?.Update();
	//改变状态时分别执行退出逻辑和加载逻辑
	public void SwitchState(BaseState newState) {
		_currentState?.Exit();
		_currentState = newState;
		_currentState?.Enter();

		OnStateChanged?.Invoke(_currentState);
	}
	public Coroutine StartCoroutine(IEnumerator routine)
	{
		if (_driver == null)
		{
			Debug.LogError("StateMgr 未初始化驱动器！");
			return null;
		}
		return _driver.StartCoroutine(routine);
	}
}
