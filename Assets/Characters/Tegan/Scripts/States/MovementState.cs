using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auriel
{
	public class MovementState : StateBase
	{
		public float moveSpeed;

		public float targetDist;
		public float turnSpeed;
		private RaycastHit rayHit;
		
		public override void Enter()
		{
			base.Enter();
			moveSpeed = 25;
			turnSpeed = 50;
		}

		public override void Execute()
		{
			base.Execute();
			
			aurielRB.AddRelativeForce(0,0, moveSpeed*Time.deltaTime, ForceMode.VelocityChange);
			
			//rb.AddForce(0, 0, moveSpeed);

			if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out rayHit))
			{
                targetDist = rayHit.distance;
                
                aurielRB.AddRelativeForce(turnSpeed, 0,0, ForceMode.Acceleration);
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayHit.distance, Color.magenta);
                Debug.Log("Hit");
			}

            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.black);
                Debug.Log("Didn't hit");
            }
		}

		public override void Exit()
		{
			base.Exit();
		}
	}
}
