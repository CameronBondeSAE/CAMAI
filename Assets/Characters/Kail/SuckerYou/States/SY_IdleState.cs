using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kail
{
    public class SY_IdleState : StateBase
    {
        
        //walks around slowly until it sees someone
        //similar to MyGuy's idle state

        //movement related
        private SuckerYouMovement moveIdle;
        public int time;
        public float speed = 3f;
        
        public StateBase idle;

        public override void Enter()
        {
            base.Enter();
            idle = GetComponent<IdleState>();
            moveIdle = GetComponentInParent<SuckerYouMovement>();
            
            MoveSet();
        }

       public override void MoveSet()
        {
            base.MoveSet();
            //moves unless it hits something, so time is high
            time = 10000;
            moveIdle.MoveSet(speed, time, idle);
        }

        public override void MoveStop()
        {
            //in case time runs out before it hits something, goes back to MoveSet
            base.MoveStop();
            MoveSet();
        }
    }
}