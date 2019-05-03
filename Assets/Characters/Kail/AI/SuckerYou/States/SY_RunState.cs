using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kail
{
    public class SY_RunState : StateBase
    {
        private SuckerYouController current;
        private SuckerYouMovement moveRun;
        private StateBase run;
        
        private void Awake()
        {
            current = GetComponentInParent<SuckerYouController>();
            moveRun = GetComponentInParent<SuckerYouMovement>();
            run = current.currentState;
        }
        
        
        public override void Enter()
        {
            base.Enter();
            //turn around, run for a while, set all attack and hurt things to false
            moveRun.MoveSet(5f,70,run);
        }

        public override void MoveEnd()
        {
            base.MoveEnd();
            current.target = null;
            current.targetFound = false;
            current.isHurt = false;
        }

        public override void Exit(int nextState)
        {
            base.Exit(nextState);
            current.target = null;
            current.targetFound = false;
            current.isHurt = false;
        }
    }
}
