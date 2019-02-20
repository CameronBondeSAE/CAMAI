using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kail
{

    public class TauntState : StateBase
    {
        public override void Enter()
        {
            base.Enter();
            
            GetComponent<Renderer>().material.color = Color.red;
        }

        public override void Update()
        {
            base.Update();
            //taunt through the behaviour tree
            //track how close enemy is
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
