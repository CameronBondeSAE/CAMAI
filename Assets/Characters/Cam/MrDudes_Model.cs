using System;
using Cam;
using Tayx.Graphy.Utils;
using UnityEditorInternal;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Cam
{
	

public class MrDudes_Model : CharacterBase
{
	private float _amountOfStuff;
	public float AmountOfStuff
	{
		get
		{
			return _amountOfStuff;
		}
		set
		{
			Debug.Log("Amount changed = "+value);
			_amountOfStuff = value;
		}
	}

	// TODO HACK remove
	public StateBase attackState;
	public StateBase wobbleState;

	
	public StateBase currentState;
	public Transform myTransform;
	public float teleportRange;
	public float getBigScalar;

	public void ChangeState(StateBase newState)
	{
		// Check current state isn't the same
		if (newState == currentState) return;

		if (currentState != null) currentState.Exit();
		if (newState != null)
		{
			newState.Enter();

			currentState = newState;
		}
		else
		{
			currentState = null;
		}
	}

	public void EndState()
	{
		// Null the statemachine, so the Behaviour Tree can set the state manually
		ChangeState(null);
	}
	

	private void Awake()
	{
		ChangeState(wobbleState);
	}

	public override void Start()
	{
		base.Start();

		myTransform = GetComponent<Transform>();
		
		// Listen/Subscribe to events coming out of Health.
		GetComponent<Health>().OnHurtEvent += MrDudes_Model_OnHurtEvent;
		GetComponent<Health>().OnDeathEvent += MrDudes_Model_OnDeathEvent;
	}

	private void Update()
	{
		// Update statemachine
		if (currentState != null) currentState.Execute();

		// TODO HACK remove
		if (Input.GetKeyDown(KeyCode.Q))
		{
			ChangeState(attackState);
		}
		if (Input.GetKeyDown(KeyCode.W))
		{
			ChangeState(wobbleState);
		}
	}

	private void MrDudes_Model_OnDeathEvent()
	{
		Destroy(gameObject);
	}

	private void MrDudes_Model_OnHurtEvent()
	{
		float scaleChange = GetComponent<Health>().lastHealthChangedAmount/100f;
		transform.localScale -= new Vector3(-scaleChange, -scaleChange, -scaleChange);
	}

	public void GetBig()
	{
		myTransform.localScale = myTransform.localScale * getBigScalar;
	}
}

}
