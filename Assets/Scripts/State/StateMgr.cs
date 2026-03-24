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
	//目前的状态
	private BaseState _currentState;
	//当状态改变时通知外部
	public event Action<BaseState> OnStateChanged;
	
	public void Tick() { 
		_currentState?.Update();
	}
	//改变状态时分别执行退出逻辑和加载逻辑
	public void SwithchState(BaseState newState) {
		_currentState?.Exit();
		_currentState = newState;
		_currentState?.Enter();

		OnStateChanged?.Invoke(_currentState);
	}
}
