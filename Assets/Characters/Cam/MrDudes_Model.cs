using Cam;
using UnityEditorInternal;
using UnityEngine;

namespace Cam
{
	

public class MrDudes_Model : CharacterBase
{
	// TODO HACK remove
	public StateBase attackState;
	public StateBase wobbleState;

	
	public StateBase currentState;

	public void ChangeState(StateBase newState)
	{
		// Check current state isn't the same
		if (currentState != null) currentState.Exit();
		newState.Enter();

		currentState = newState;
	}

	private void Awake()
	{
		ChangeState(wobbleState);
	}

	public override void Start()
	{
		base.Start();

		// Listen/Subscribe to events coming out of Health.
		GetComponent<Health>().OnHurtEvent += MrDudes_Model_OnHurtEvent;
		GetComponent<Health>().OnDeathEvent += MrDudes_Model_OnDeathEvent;
	}

	private void Update()
	{
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
}

}
