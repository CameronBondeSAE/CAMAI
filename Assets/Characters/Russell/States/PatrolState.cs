using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Russell {
    public class PatrolState : StateBase
        
    {
        public event Action OnDoneMoving;
        public Rigidbody rb;
        public float moveSpeed = 5f;
        //public float minMoveDistance = 10;
        
        public override void Enter()
        {
            base.Enter();           
            Invoke("RunEvent", 5f);
            Debug.Log("Start Moving", gameObject);
        }

        public override void Execute()
        {
            base.Execute();
            rb.velocity = transform.forward * 10;
            //;
            Ray ray;          
            ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            RaycastHit leftHit;
            RaycastHit rightHit;
            RaycastHit leftSideHit;
            RaycastHit rightSideHit;
            Vector3 origin = transform.position;
            if (Physics.Raycast(ray, out hit, 50f))
            {
                //HACK TESTING if something gets hit
                if (hit.collider.tag == "Target")
                {
                    Debug.DrawLine(ray.origin, hit.point, Color.red);
                    Debug.Log(hit.collider.name + "is my target");
                }
                else
                {
                    rb.velocity += transform.forward * moveSpeed * Time.deltaTime;
                    Debug.DrawLine(ray.origin, hit.point, Color.blue);
                }
                if (Physics.Raycast(origin, Quaternion.AngleAxis(45f, transform.up) * transform.forward, out rightHit, 20f))
                {
                    transform.Rotate(0, -80 * Time.deltaTime, 0); 
                    Debug.DrawLine(origin, rightHit.point, Color.yellow);
                }
                else if (Physics.Raycast(origin, Quaternion.AngleAxis(-45f, transform.up) * transform.forward, out leftHit, 20f))
                {
                    transform.Rotate(0, 80 * Time.deltaTime, 0); 
                    Debug.DrawLine(origin, leftHit.point, Color.cyan);
                }

                if (Physics.Raycast(origin, Quaternion.AngleAxis(90f, transform.up) * transform.forward, out rightSideHit,
                    10f))
                {
                    transform.Rotate(0, -80 * Time.deltaTime, 0); 
                    Debug.DrawLine(origin, rightSideHit.point, Color.yellow);
                }
                if (Physics.Raycast(origin, Quaternion.AngleAxis(90f, transform.up) * transform.forward, out leftSideHit,
                    10f))
                {
                    transform.Rotate(0, 80 * Time.deltaTime, 0); 
                    Debug.DrawLine(origin, leftSideHit.point, Color.cyan);
                }
            }



        }

        public override void Exit()
        {
            base.Exit();
            GetComponent<Rigidbody>().velocity = transform.forward * 0;

        }

        private void RunEvent()
        {
            //OnDoneMoving();
        }
    }
}

