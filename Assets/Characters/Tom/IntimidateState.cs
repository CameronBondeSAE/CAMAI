using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tom;

namespace Tom
{
    public class IntimidateState : StateBase
    {
        
        public Transform myTransform;
        public float getBigScalar;
        
        public override void Enter()
        {
            base.Enter();
        }

        public override void Execute()
        {
            base.Execute();
        }

        public override void Exit()
        {
            base.Exit();
        }
        
        public void BeefUp()
        {
            myTransform.localScale = myTransform.localScale * getBigScalar;
        }
        
    }
    
}