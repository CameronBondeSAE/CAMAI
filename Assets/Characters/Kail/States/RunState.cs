using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kail
{

    public class RunState : StateBase
    {
        
        public MyGuyMovement movementRun;
        public StateBase run;
        public int time;
        public float speed = 9f;
        
        
        public override void Enter()
        {
            base.Enter();
            
            GetComponent<Renderer>().material.color = Color.yellow;
            
            movementRun = GetComponent<MyGuyMovement>();
            run = GetComponent<RunState>();
            MoveSet();
        }

        public override void Update()
        {
            base.Update();
            //track how far away enemy is
        }
        
        public override void MoveSet()
        {
            base.MoveSet();
            time = Random.Range(100, 150);
            this.transform.Rotate(0f,180,0f);
            movementRun.MoveStart(run, speed, time);
        }
        
        public override void MoveEnd()
        {
            base.MoveEnd();
            this.transform.Rotate(0f,-180,0f);
            //check distance between you and target
        }

        public override void MoveStop()
        {
            base.MoveStop();
            movementRun.MoveOverride();
        }

        public override void Exit()
        {
            movementRun.MoveOverride();
        }
        
        
    }
}