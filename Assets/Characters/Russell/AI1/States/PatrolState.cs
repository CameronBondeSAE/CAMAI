using System;
using TMPro;
using UnityEngine;

namespace Russell
{
    public class PatrolState : StateBase

    {
        public WhosAround _whosAround;
        public Kyllarr_Model model;
        public GameObject aI;

        public FieldOfView fov;
        //public float minMoveDistance = 10;
        public float distanceCheck = 10f;
        public RaycastHit floorHit;
        public RaycastHit leftHit;
        public RaycastHit leftSideHit;
        public float moveSpeed = 5f;

        public GameObject myTarget;
        public Rigidbody rb;
        public RaycastHit rightHit;
        public RaycastHit rightSideHit;


        private void Awake()
        {
            _whosAround = aI.GetComponent<WhosAround>();
            model = aI.GetComponent<Kyllarr_Model>();
            fov = aI.GetComponent<FieldOfView>();
            
        }

        public override void Enter()
        {
            base.Enter();
            //for testing
            //InvokeRepeating("GetTarget", 3,5);
            //Debug.Log("Start Moving", gameObject);
            
        }

        public override void Execute()
        {
            base.Execute();
            model.debugText = "Patrolling";
            RayCastDistanceCheck();
            rb.velocity = transform.forward * 10;
            //;
            Ray ray;
            ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            var origin = transform.position;
            if (Physics.Raycast(origin, Quaternion.AngleAxis(20f, transform.right) * transform.forward, out floorHit, 8f))
            {
                
                Debug.DrawLine(ray.origin, floorHit.point, Color.red);
                if (Physics.Raycast(ray, out hit, 50f))
                {
                    //Will Need to change to add force
                    var characterBase = hit.collider.GetComponent<CharacterBase>();
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
                        rb.AddForce(0, 0, moveSpeed * Time.deltaTime);
                        //Debug.DrawLine(ray.origin, hit.point, Color.blue);
                    }

                    if (Physics.Raycast(origin, Quaternion.AngleAxis(45f, transform.up) * transform.forward,
                        out rightHit, 10f))
                        rb.transform.Rotate(0, -80 * Time.deltaTime, 0);
                    else if (Physics.Raycast(origin, Quaternion.AngleAxis(-45f, transform.up) * transform.forward,
                        out leftHit, 10f)) rb.transform.Rotate(0, 80 * Time.deltaTime, 0);

                    if (Physics.Raycast(origin, Quaternion.AngleAxis(90f, transform.up) * transform.forward,
                        out rightSideHit,
                        5f))
                        rb.transform.Rotate(0, -120 * Time.deltaTime, 0);
                    if (Physics.Raycast(origin, Quaternion.AngleAxis(-90f, transform.up) * transform.forward,
                        out leftSideHit,
                        5f))
                        rb.transform.Rotate(0, 120 * Time.deltaTime, 0);
                }
            }
            else
            {
                rb.AddRelativeTorque(0, -80000, 0);
            }
            
            
        }

        public override void Exit()
        {
            base.Exit();
            rb.velocity = transform.forward * 0;
        }

        public void GetTarget()
        {
            fov.FindVisibleTargets();
        }



        public void RayCastDistanceCheck()
        {
            foreach (var aiAround in _whosAround.whosAround)
                if (aiAround != null)
                {
                    float distance;


                    if (Physics.Raycast(transform.position, transform.position - aiAround.transform.position,
                        _whosAround.radius))
                    {
                        distance = Vector3.Distance(transform.position, aiAround.transform.position);
                        if (distance <= distanceCheck)
                        {
                            myTarget = aiAround.gameObject;
                            var localTargetOffset = transform.InverseTransformPoint(myTarget.transform.position);

                            if (localTargetOffset.x < 0)
                                rb.AddRelativeTorque(0, 20000, 0);
                            else if (localTargetOffset.x > 0) rb.AddRelativeTorque(0, -20000, 0);
                            //move character away from close object
                        }
                    }
                }
        }
    }
}