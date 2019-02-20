using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Michael
{
    public class MagicMissleState : StateBase
    {
        [SerializeField] private GameObject missle;
        public override void Enter()
        {
            base.Enter();
        }
        
        public override void Execute()
        {
            /*
             * check distance from target
             * check if any abilities are usable
             * Move if out of range
             * when in range use ability
             */
            
            base.Execute();
            print("Attacking");
        }

        public override void Exit()
        {
            //Instantiate(missle, (transform.position + transform.forward,);
            base.Exit();
            print("Exit of attack");
        }
    }
}
