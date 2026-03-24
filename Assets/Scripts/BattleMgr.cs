using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleMgr : MonoBehaviour
{
	void Start()
	{
		StateMgr.Instance.OnStateChanged += HandleStateChanged;
		StateMgr.Instance.SwithchState(new SetupState());
	}

	void Update()
	{
		//StateMgr.Instance.Tick();  
		if(Input.GetMouseButtonDown(0))
			StateMgr.Instance.SwithchState(new PlayerDrawState());
		if(Input.GetMouseButtonDown(1))
			StateMgr.Instance.SwithchState(new PlayerTurnState());
		if(Input.GetKeyDown(KeyCode.Space))
			StateMgr.Instance.SwithchState(new EnemyTurnState());
	}
	void OnDestroy() { 
		StateMgr.Instance.OnStateChanged -= HandleStateChanged;
	}

	private void HandleStateChanged(BaseState state) {
		Debug.Log("State changed to " + state.GetType().Name);
	}
}
