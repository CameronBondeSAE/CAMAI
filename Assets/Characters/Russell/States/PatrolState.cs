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

        public GameObject myTarget;
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
                //Will Need to change to add force
                CharacterBase characterBase = hit.collider.GetComponent<CharacterBase>();
                if (characterBase != null && characterBase != this)
                {
                    myTarget = hit.collider.gameObject;
                    rb.GetComponent<CharacterBase>().Target = myTarget;

                    if (myTarget != null)
                    {
                        //rb.velocity += Vector3.MoveTowards(transform.position, myTarget.transform.position, )
                    }
                }
                //HACK TESTING if something gets hit
                else
                {
                    rb.AddForce(0,0,moveSpeed *Time.deltaTime);
                    Debug.DrawLine(ray.origin, hit.point, Color.blue);
                }
                if (Physics.Raycast(origin, Quaternion.AngleAxis(45f, transform.up) * transform.forward, out rightHit, 10f))
                {
                    rb.transform.Rotate(0, -80 * Time.deltaTime, 0); 
                    Debug.DrawLine(origin, rightHit.point, Color.yellow);
                }
                else if (Physics.Raycast(origin, Quaternion.AngleAxis(-45f, transform.up) * transform.forward, out leftHit, 10f))
                {
                    rb.transform.Rotate(0, 80 * Time.deltaTime, 0); 
                    Debug.DrawLine(origin, leftHit.point, Color.cyan);
                }

                if (Physics.Raycast(origin, Quaternion.AngleAxis(90f, transform.up) * transform.forward, out rightSideHit,
                    5f))
                {
                    rb.transform.Rotate(0, -120 * Time.deltaTime, 0); 
                    Debug.DrawLine(origin, rightSideHit.point, Color.yellow);
                }
                if (Physics.Raycast(origin, Quaternion.AngleAxis(-90f, transform.up) * transform.forward, out leftSideHit,
                    5f))
                {
                    rb.transform.Rotate(0, 120 * Time.deltaTime, 0); 
                    Debug.DrawLine(origin, leftSideHit.point, Color.cyan);
                }
            }



        }

        public override void Exit()
        {
            base.Exit();
            rb.velocity = transform.forward * 0;

        }

        private void RunEvent()
        {
            //OnDoneMoving();
        }
    }
}

