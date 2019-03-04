using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auriel
{
	public class StateBase : MonoBehaviour
	{
		public Rigidbody aurielRB;
		
		public virtual void Enter()
		{
			aurielRB = GetComponent<Rigidbody>();
		}

		public virtual void Execute()
		{

		}

		public virtual void Exit()
		{

		}
	}
}
