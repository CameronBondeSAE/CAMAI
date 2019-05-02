using System.Collections;
using System.Collections.Generic;
using Russell;
using UnityEngine;
using System;

namespace Russell
{
    public class RotateState : StateBase
    {
        public event Action OnDoneRotating;
        public override void Enter()
        {
            base.Enter();
            transform.Rotate(0, 90, 0);
            Invoke("RunEvent", 5f);
        }
    
        public override void Execute()
        {
            base.Execute();
        }
    
        public override void Exit()
        {
            base.Exit();
            

        }
        private void RunEvent()
        {
            OnDoneRotating();
        }
    }

}

