using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

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

        private Rigidbody rb;
        public int turningTime;
        private bool turned;

        public bool move;

        public override void Enter()
        {
            base.Enter();
            idle = this;
            moveIdle = GetComponentInParent<SuckerYouMovement>();
            rb = GetComponentInParent<Rigidbody>();
            move = true;
            
            MoveSet();
        }

       public override void MoveSet()
        {
            base.MoveSet();
            //moves unless it hits something, so time is high
            time = UnityEngine.Random.Range(300, 1000);
            moveIdle.MoveSet(speed, time, idle);
        }

        public override void MoveEnd()
        {
            //set it up to add relative torque for x about of time in its own update function, then it goes back to moveset
            //base.MoveStop();
            turned = false;
            turningTime = UnityEngine.Random.Range(100,200);
            MoveSet();
            
            

        }

        private void FixedUpdate()
        {
            if (turningTime > 0)
            {
                rb.AddRelativeTorque(0, 30*2, 0);
                turningTime--;
            }

            if ((turningTime <= 0) && (turned == false))
            {
                turningTime = 0;
                turned = true;
            }
        }

        public override void Exit(int nextState)
        {
            base.Exit(nextState);
            moveIdle.MoveOverride();
        }
    }
}