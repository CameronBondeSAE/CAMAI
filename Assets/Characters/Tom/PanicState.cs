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
            Invoke("ChangeToPanic", 3);
            TeleportRandomly();
            Debug.Log("panicStart", gameObject);
        }

        public void ChangeToPanic()
        {
            
            GetComponent<Cindy_Model>().ChangeState(GetComponent<PanicState>());
        }
        
        public override void Execute()
        {
            base.Execute();
            
            Debug.Log("panicExecute", gameObject);
        }

        public override void Exit()
        {
            base.Exit();
            
            Debug.Log("panicExit", gameObject);
        }
        
        
        public void TeleportRandomly()
        {
            myTransform.position = myTransform.position + new Vector3(Random.Range(-teleportRange, teleportRange), Random.Range(-teleportRange, teleportRange), Random.Range(-teleportRange, teleportRange));
        }
    }
}

