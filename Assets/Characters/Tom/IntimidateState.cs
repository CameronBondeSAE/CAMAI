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
            float scaleChange = GetComponent<Health>().lastHealthChangedAmount / 100f;
            transform.localScale -= new Vector3(-scaleChange, -scaleChange, -scaleChange);
        }
        
    }
    
}