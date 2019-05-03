using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tegan
{
	public class StateBase : MonoBehaviour
	{
		public virtual void Enter()
		{
			
		}

		public virtual void Execute()
		{

		}

		public virtual void Exit()
		{
			GetComponentInParent<AurielBehaviourTree>().NextMove();
		}
	}
}
