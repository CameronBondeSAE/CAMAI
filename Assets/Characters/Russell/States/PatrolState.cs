using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Russell {
    public class PatrolState : StateBase
        
    {
        public event Action OnDoneMoving;
        public Rigidbody rb;
        
        private Vector3 leftMoveRay;
        private Vector3 rightMoveRay;
        public float minMoveDistance = 10;
        
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
            Debug.Log("Im moving", gameObject);
            RaycastHit hit;           
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
//                if()
                Debug.Log(hit.transform.name);

            }



        }

        public override void Exit()
        {
            base.Exit();
            GetComponent<Rigidbody>().velocity = transform.forward * 0;

        }

        private void RunEvent()
        {
            OnDoneMoving();
        }
    }
}

