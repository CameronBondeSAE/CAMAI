using System.Collections;
using System.Collections.Generic;
using Josh;
using UnityEngine;

namespace Josh
{
    public class SpinState : StateBase
    {
        public float basespeed = 1;
        public float maxspeed = 9;
        public float power = 0.5f;
        public float completion = 0;
        public Rigidbody thisone;
        public override void Enter()
        {
            base.Enter();
            thisone = gameObject.GetComponent<Rigidbody>();
            power = gameObject.GetComponent<Energy>().Amount / gameObject.GetComponent<Energy>().MaxEnergy;
            thisone.angularVelocity.Set(0,1,0);
            Debug.Log("SpinStart",gameObject);
        }

        public override void Execute()
        {
            base.Execute();
            completion += basespeed+ (Time.deltaTime * power * maxspeed);
            gameObject.transform.Rotate(Vector3.up,basespeed+(Time.deltaTime*maxspeed*power));
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
