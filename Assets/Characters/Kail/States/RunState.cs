﻿using System.Collections;
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

        public float oldY;
        
        public Radar checkDist;
        public bool pause;


        private void Awake()
        {
            checkDist = GetComponent<Radar>();
            movementRun = GetComponent<MyGuyMovement>();
            run = GetComponent<RunState>();
        }

        public override void Enter()
        {
            base.Enter();
            
            MoveSet();
        }

                
        public override void MoveSet()
        {
            base.MoveSet();
            time = Random.Range(100, 150);
            oldY = this.transform.rotation.y;
            this.transform.Rotate(0f,180f,0f);
            movementRun.MoveStart(run, speed, time);
        }
        
        public override void MoveEnd()
        {
            base.MoveEnd();
            this.transform.Rotate(0f, oldY, 0f);  //does not work
            checkDist.LookAtEnemy();
            
            
        }

        public override void MoveStop()
        {
            base.MoveStop();
            movementRun.MoveOverride();
        }


        public override void Update()
        {

            if (checkDist.look == true)
            {
                //transform.LookAt(checkDist.transform.position);

                /*sets the rotation.x to 0f, because i want that
                var tempRot = new Quaternion();
                tempRot.Set(0f, transform.rotation.y, 0f, 1);
                transform.rotation = tempRot;*/

                if (pause == false)
                {
                    movementRun.MoveOverride();
                    pause = true;
                    
                }
            }

        }


        public override void Exit(int nextState)
        {
            base.Exit(nextState);
            movementRun.MoveOverride();
            
            var tempRot = new Quaternion();
            tempRot.Set(0f, transform.rotation.y, 0f, 1);
            transform.rotation = tempRot;
            
            switch (nextState)
            {
                case 0:
                    GetComponent<Radar>().TargetNotFound();
                    GetComponent<Renderer>().material.color = Color.gray;
                    break;
                case 1:
                    GetComponent<Renderer>().material.color = Color.red;
                    break;
                
            }
            
        }
        
        
    }
}