using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auriel
{
	public class MovementState : StateBase
	{
		public Rigidbody rb;
		public float moveSpeed;
		
		public override void Enter()
		{
			base.Enter();
			rb = GetComponent<Rigidbody>();
			moveSpeed = 25;
		}

		public override void Execute()
		{
			base.Execute();
			rb.AddRelativeForce(0,0, moveSpeed*Time.deltaTime, ForceMode.VelocityChange);
		}

		public override void Exit()
		{
			base.Exit();
		}
	}
}
