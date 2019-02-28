﻿using System.Collections;
using System.Collections.Generic;
using Josh;
using UnityEngine;

namespace Josh
{
    public class WalkState : StateBase
    {
        public float speed = 3;
        public Rigidbody body;
        public Transform worldprop;
        public override void Enter()
        {
            base.Enter();
            Debug.Log("Walk start",gameObject);
            worldprop = transform.parent;
            body = worldprop.GetComponent<Rigidbody>();
        }

        public override void Execute()
        {
            base.Execute();
            float distleft = castray(worldprop.position, (-worldprop.right + worldprop.forward));
            float distright = castray(worldprop.position, (worldprop.right + worldprop.forward));
            float dist = castray(worldprop.position, (worldprop.forward)*Mathf.Sqrt(2));
            if ( distleft >= 2f && distright >= 2f)
            {
                if(dist <= 2)
                {
                    //body.AddTorque(0,speed*3,0);
                    //body.angularVelocity=new Vector3(0,speed*3,0);
                }
                else
                {
                    body.AddTorque(-body.angularVelocity,ForceMode.VelocityChange);
                    //Debug.Log("straight");
                    //body.angularVelocity=new Vector3(0,0,0);
                }
            }
            else if (distleft > distright)
            {
                body.AddTorque(0,-speed,0,ForceMode.VelocityChange);
                //body.angularVelocity=new Vector3(0,-speed*2,0);
            }
            else
            {
                body.AddTorque(0,speed,0,ForceMode.VelocityChange);
                //body.angularVelocity=new Vector3(0,speed*2,0);
            }
            
            body.AddForce(worldprop.forward*speed,ForceMode.VelocityChange);
            //Debug.Log("Eg update",gameObject);
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("Walk exit",gameObject);
        }
        public float castray(Vector3 start, Vector3 directiondist)
        {
            RaycastHit hit;
            Physics.Raycast(start, directiondist, out hit);
            return hit.distance;
        }
    }
}