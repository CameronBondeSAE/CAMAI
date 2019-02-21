using System.Collections;
using System.Collections.Generic;
using Josh;
using UnityEngine;

namespace Josh
{
    public class SpinState : StateBase
    {
        public Rigidbody body;
        public float originalrot;
        public float basespeed = 1;
        public float maxspeed = 9;
        public float power = 0.5f;
        public float completion = 0;
        public override void Enter()
        {
            base.Enter();
            body = gameObject.GetComponent<Rigidbody>();
            originalrot = gameObject.transform.eulerAngles.y;
            Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, 3);
            power = gameObject.GetComponent<Energy>().Amount / gameObject.GetComponent<Energy>().MaxEnergy;
            Debug.Log("SpinStart",gameObject);
        }

        public override void Execute()
        {
            base.Execute();
            completion += basespeed+ (Time.deltaTime * power * maxspeed);
            body.angularVelocity.Set(0,1,0);
            //gameObject.transform.Rotate(Vector3.up,basespeed+(Time.deltaTime*maxspeed*power));
            if (completion >= 360)
            {
                Exit();
            }
            Debug.Log("Bupdate",gameObject);
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("Bexit",gameObject);
        }
    }
}
