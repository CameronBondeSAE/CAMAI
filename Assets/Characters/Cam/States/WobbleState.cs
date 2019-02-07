using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Cam;
using UnityEngine;

namespace Cam
{
  
    public class WobbleState : StateBase
    {
        public override void Enter()
        {
            base.Enter();
            
            Invoke("ChangeToAttack", 3);
            
            Debug.Log("WobbleStart", gameObject);
        }

        public void ChangeToAttack()
        {
            
            GetComponent<MrDudes_Model>().ChangeState(GetComponent<AttackState>());
        }

        public override void Execute()
        {
            base.Execute();
            Debug.Log("WobbleUpdate", gameObject);
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("WobbleExit", gameObject);
        }
    }
  

}
