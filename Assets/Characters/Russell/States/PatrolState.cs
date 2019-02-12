using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Russell {
    public class PatrolState : StateBase
        
    {
        public event Action OnDoneMoving;
        public override void Enter()
        {
            base.Enter();
            Invoke("RunEvent", 5f);
            Debug.Log("Start Moving", gameObject);
        }

        public override void Execute()
        {
            base.Execute();
            GetComponent<Rigidbody>().velocity = transform.forward * 10;
            Debug.Log("Im moving", gameObject);
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

