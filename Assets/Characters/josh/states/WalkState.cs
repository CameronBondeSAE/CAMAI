using System.Collections;
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
            float distleft = castray(worldprop.position+(-worldprop.right + worldprop.forward).normalized, (-worldprop.right + worldprop.forward).normalized*10);
            float distright = castray(worldprop.position+(worldprop.right + worldprop.forward).normalized, (worldprop.right + worldprop.forward).normalized*10);
            float dist = castray(worldprop.position+worldprop.forward, (worldprop.forward)*10);
            Debug.DrawRay(worldprop.position+(-worldprop.right + worldprop.forward).normalized, (-worldprop.right + worldprop.forward).normalized*10);
            Debug.DrawRay(worldprop.position+(worldprop.right + worldprop.forward).normalized, (worldprop.right + worldprop.forward).normalized*10);
            Debug.DrawRay(worldprop.position+worldprop.forward,  worldprop.forward*10);
            /*
            if ( distleft >= 3f && distright >= 3f)
            {
                if(dist <= 3)
                {
                    //body.AddTorque(0,speed*3,0);
                    //body.angularVelocity=new Vector3(0,speed*3,0);
                }
                else
                {
                    //body.AddTorque(-body.angularVelocity,ForceMode.VelocityChange);
                    //Debug.Log("straight");
                    //body.angularVelocity=new Vector3(0,0,0);
                }
            }
            else if (distleft > distright)
            {
                body.AddTorque(0,-speed*3/distright,0,ForceMode.VelocityChange);
                //body.angularVelocity=new Vector3(0,-speed*2,0);
            }
            else
            {
                body.AddTorque(0,speed*3/distleft,0,ForceMode.VelocityChange);
                //body.angularVelocity=new Vector3(0,speed*2,0);
            }
            */
            body.AddForce(worldprop.forward*speed,ForceMode.VelocityChange);
            body.AddTorque(0,speed*(1-(distleft/10)),0,ForceMode.VelocityChange);
            body.AddTorque(0,-speed*(1-(distright/10)),0,ForceMode.VelocityChange);
            body.AddTorque(0,speed*(1-(dist/10)),0,ForceMode.VelocityChange);
            //body.angularVelocity = Vector3.ClampMagnitude(body.angularVelocity,4);
            body.velocity = Vector3.ClampMagnitude(body.velocity,3);
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
            Physics.Raycast(start, directiondist.normalized, out hit, directiondist.magnitude);
            return hit.distance;
        }
    }
}
