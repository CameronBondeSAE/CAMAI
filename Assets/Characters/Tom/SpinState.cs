using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tom;

namespace Tom
{
    public class SpinState : StateBase
    {
        
        public Transform myTransform;
        public float speed = 10f;
        
        public override void Enter()
        {
            base.Enter();
            myTransform = GetComponent<Transform>();
            // Debug.Log("panicStart", gameObject);
        }
        
        public override void Execute()
        {
            base.Execute();    
            Spin();
            // Debug.Log("panicExecute", gameObject);
        }

        public override void Exit()
        {
            base.Exit();
            
            // Debug.Log("panicExit", gameObject);
        }
        
        
        public void Spin()
        {
            transform.Rotate(Vector3.up, speed * Time.deltaTime);           
        }
    }
}