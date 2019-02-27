using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auriel
{
	public class Auriel_Model : CharacterBase
	{
		public StateBase attackState;
		public StateBase idleState;
		public StateBase movementState;

		public StateBase currentState;

		public void ChangeState (StateBase newState)
		{
			//currentState.Exit();
			newState.Enter();
			currentState = newState;
		}

		private void Awake()
		{
			ChangeState(movementState);

			GetComponent<Health>().OnHurtEvent += AurielHurt;
			GetComponent<Health>().OnDeathEvent += AurielDeath;
		}

		public override void Start()
		{
			base.Start();
		}

		public void Update() 
		{
			if (currentState != null)
			{
				currentState.Execute();
			}
		}
		
		private void AurielHurt()
		{
			
		}
		
		private void AurielDeath()
		{
			Destroy(gameObject);
		}
	}
}
