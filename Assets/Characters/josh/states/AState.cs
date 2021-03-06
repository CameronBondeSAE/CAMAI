﻿using System.Collections;
using System.Collections.Generic;
using Josh;
using UnityEngine;

namespace Josh
{
    public class AState : StateBase
    {
        public override void Enter()
        {
            base.Enter();
            Debug.Log("Astart",gameObject);
        }

        public override void Execute()
        {
            base.Execute();
            RaycastHit hit;
            if (Physics.Raycast(gameObject.transform.position, Vector3.down, out hit, Mathf.Infinity))
            {
                if (hit.distance <= 2)
                {
                    //gameObject.GetComponent<StateMachine>().ChangeState(null);
                    Exit();
                }
                else
                {
                    gameObject.transform.Translate(Vector3.down);
                }
            }
            Debug.Log("Aupdate",gameObject);
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("Aexit",gameObject);
        }
    }
}
