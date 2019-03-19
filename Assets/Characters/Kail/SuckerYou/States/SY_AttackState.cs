using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kail
{
    public class Sy_AttackState : StateBase
    {
        //starts once its attached to the target


        public override void Exit(int nextState)
        {
            base.Exit(nextState);
            //if next state is idle, jumps off, attacks once more, then goes to idle
            //if next state is run, jumps off and flees
        }
    }
}