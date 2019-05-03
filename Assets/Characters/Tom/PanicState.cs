using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tom;

namespace Tom
{
    public class PanicState : StateBase
    {
        public Transform myTransform;
        public float teleportRange;
        
        public override void Enter()
        {
            base.Enter();
            myTransform = GetComponent<Transform>();
           // Debug.Log("panicStart", gameObject);
        }
        
        public override void Execute()
        {
            base.Execute();
            PanicTeleport();
           // Debug.Log("panicExecute", gameObject);
        }

        public override void Exit()
        {
            base.Exit();
            
           // Debug.Log("panicExit", gameObject);
        }
        
        
        public void PanicTeleport()
        {
            myTransform.position = myTransform.position + new Vector3(Random.Range(-teleportRange, teleportRange), Random.Range(-teleportRange, teleportRange), Random.Range(-teleportRange, teleportRange));
        }
    }
}

