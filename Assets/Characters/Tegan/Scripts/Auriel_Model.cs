using System.Collections;
using System.Collections.Generic;
using Tom;
using UnityEditorInternal;
using UnityEngine;

namespace Tegan
{
	public class Auriel_Model : CharacterBase
	{
		public StateBase idleState;
		public StateBase movementState;
		public StateBase deathState;
		public StateBase entangleState;
		public StateBase poisonBurstState;
		public StateBase soulSiphonState;

		public StateBase currentState;

		public void ChangeState (StateBase newState)
		{
			if (currentState == deathState) return;

			newState.Enter();
			currentState = newState;
		}

		private void Awake()
		{
			idleState = GetComponentInChildren<IdleState>();
			movementState = GetComponentInChildren<MovementState>();
			deathState = GetComponentInChildren<DeathState>();
			entangleState = GetComponentInChildren<Entangle>();
			poisonBurstState = GetComponentInChildren<PoisonBurst>();
			soulSiphonState = GetComponentInChildren<SoulSiphon>();

			currentState = movementState;
			currentState.Enter();
			
			GetComponent<Health>().OnHurtEvent += AurielHurt;
			GetComponent<Health>().OnDeathEvent += AurielDeath;
		}

		/*public override void Start()
		{
			
		}*/

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
			ChangeState(deathState);
		}
	}
}
