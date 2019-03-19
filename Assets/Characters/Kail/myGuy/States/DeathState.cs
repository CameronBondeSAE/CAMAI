using System.Collections;
using System.Collections.Generic;
using NodeCanvas.Tasks.Actions;
using UnityEngine;

namespace Kail
{
    public class DeathState : StateBase
    {
        
        //called when the health reaches 0
        public override void Enter()
        {
            base.Enter();
            Debug.Log("I have done nothing to deserve this!");
            Destroy(this);
        }
    }
}