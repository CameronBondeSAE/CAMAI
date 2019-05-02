using System.Collections;
using System.Collections.Generic;
using Tom;
using UnityEngine;

namespace Tom
{
    public class IdleState : StateBase
    {
        public override void Enter()
        {
            base.Enter();
            
            //Debug.Log("IdleStart", gameObject);
        }

        public override void Execute()
        {
            base.Execute();
            
           // Debug.Log("IdleExecute", gameObject);
        }

        public override void Exit()
        {
            base.Exit();
            
           // Debug.Log("IdleExit", gameObject);
        }
    }
}