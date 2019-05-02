using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace Russell
{
    public class HoverState : StateBase
    {
        public GameObject parent;
        public Rigidbody rb;
        public Kyllarr_Model ai;
        public  float endPos = 20;
        public event Action TargetAquired;
        public BarrageAbility barrageAbility;

        private void Awake()
        {
            rb = parent.GetComponent<Rigidbody>();
            ai = parent.GetComponent<Kyllarr_Model>();
        }

        public override void Enter()
        {
            base.Enter();
            if (!ai.Target) ai.ChangeState(ai.patrolState);
            else StartCoroutine(WaitASec());
            TargetAquired();
            ai.debugText = "Hovering";


        }

        public override void Execute()
        {
            base.Execute();
            parent.transform.position = Vector3.Lerp(parent.transform.position,
                (new Vector3(parent.transform.position.x, endPos, parent.transform.position.z)), 5 * Time.deltaTime);
            if (ai.Target != null)
            {
                parent.transform.LookAt(ai.Target.transform);
                
            }
            
            rb.useGravity = false;
            
        }

        public override void Exit()
        {
            base.Exit();
            parent.transform.rotation = Quaternion.identity;
            parent.transform.position = new Vector3(parent.transform.position.x, 1, parent.transform.position.z);
            
            barrageAbility.coll.enabled = false;
            rb.useGravity = true;
            

            
            
            

            
        }

        IEnumerator WaitASec()
        {
            yield return new WaitForSeconds(5);                
            ai.ChangeState(ai.patrolState);
        }
    }


}

    