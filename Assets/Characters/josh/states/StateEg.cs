using System.Collections;
using System.Collections.Generic;
using Josh;
using UnityEngine;

namespace Josh
{
    public class StateEg : StateBase
    {
        public override void Enter()
        {
            base.Enter();
            Debug.Log("Eg start",gameObject);
        }

        public override void Execute()
        {
            base.Execute();
            Debug.Log("Eg update",gameObject);
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("Eg exit",gameObject);
        }
    }
}
