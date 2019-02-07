using System.Collections;
using System.Collections.Generic;
using Josh;
using UnityEngine;

namespace Josh
{
    public class BState : StateBase
    {
        public override void Enter()
        {
            base.Enter();
            Debug.Log("Bstart",gameObject);
        }

        public override void Execute()
        {
            base.Execute();
            Debug.Log("Bupdate",gameObject);
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("Bexit",gameObject);
        }
    }
}
