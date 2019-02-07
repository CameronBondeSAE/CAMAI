using System.Collections;
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
            Debug.Log("Aupdate",gameObject);
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("Aexit",gameObject);
        }
    }
}
