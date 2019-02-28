using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tom;

namespace Tom
{
    public class AttackState : StateBase
    {
        public override void Enter()
        {
            base.Enter();
            
            Debug.Log("attackStart", gameObject);
        }

        public override void Execute()
        {
            base.Execute();
            
            Debug.Log("attackExecute", gameObject);
        }

        public override void Exit()
        {
            base.Exit();
            
            Debug.Log("attackExit", gameObject);
        }
    }
}

