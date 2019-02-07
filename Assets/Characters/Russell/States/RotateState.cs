using System.Collections;
using System.Collections.Generic;
using Russell;
using UnityEngine;

namespace Russell
{
    public class RotateState : StateBase
    {
        
        public override void Enter()
        {
            transform.Rotate(0, 90, 0);
            StartCoroutine(Delay());
            // TODO HACK shouldn't know about attack state, use transitions? etc
           // Invoke(GetComponent<Kyllarr_Model>().ChangeState(),3);
            base.Enter();
        }

        IEnumerator Delay()
        {
            yield return new WaitForSeconds(3);
        }
    
        public override void Execute()
        {
            base.Execute();
        }
    
        public override void Exit()
        {
            base.Exit();
        }
    }

}

