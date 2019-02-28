using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

namespace Kail
{

    public class IdleState : StateBase
    {
        public MyGuyMovement movementIdle;
        public StateBase idle;
        public int time;
        public float speed = 3f;
        public float angle;

        
        public override void Enter()
        {
            base.Enter();
            idle = GetComponent<IdleState>();
            movementIdle = GetComponent<MyGuyMovement>();
            
            MoveSet();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void MoveSet()
        {
            
            base.MoveSet();
            angle = Random.Range(-90, 90);
            time = Random.Range(25, 100);
            this.transform.Rotate(0f,angle,0f);
            movementIdle.MoveStart(idle, speed, time);

        }
        
        public override void MoveEnd()
        {
            base.MoveEnd();
            MoveSet();
        }
        
        public override void MoveStop()
        {
            base.MoveStop();
            movementIdle.MoveOverride();
        }
        
        public override void Exit(int nextState)
        {
            base.Exit(nextState);
            movementIdle.MoveOverride();
            switch (nextState)
            {
                case 1:
                    GetComponent<Renderer>().material.color = Color.red;
                    break;
                case 2:
                    GetComponent<Renderer>().material.color = Color.yellow;
                    break;
                
            }
        }

    }
}