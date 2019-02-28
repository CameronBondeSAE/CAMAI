using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auriel
{
	public class MovementState : StateBase
	{
		public Rigidbody rb;
		public float moveSpeed;

		//private RaycastHit rayHit;
		
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
/*
			if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out rayHit,
				Mathf.Infinity))
			{
				Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayHit.distance, Color.magenta);
				Debug.Log("Hit");
			}

			else
			{
				Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.black);
				Debug.Log("Didn't hit");
			}
*/
		}

		public override void Exit()
		{
			base.Exit();
		}
	}
}
