using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tom;

namespace Tom
{
    public class CalmState : StateBase
    {
        
        public Transform myTransform;
        private Renderer renderer;
        
        public override void Enter()
        {
            base.Enter();
            myTransform = GetComponent<Transform>();
            // Debug.Log("panicStart", gameObject);
        }
        
        public override void Execute()
        {
            base.Execute();    
            TurnBlue();
            // Debug.Log("panicExecute", gameObject);
        }

        public override void Exit()
        {
            base.Exit();
            
            // Debug.Log("panicExit", gameObject);
        }
        
        
        public void TurnBlue()
        {
            renderer.material.color = Color.blue;
        }
    }
}