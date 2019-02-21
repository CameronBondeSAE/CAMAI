using UnityEngine;

namespace Kennith
{
    public class FleeState : StateBase
    {
        public override void Enter()
        {
            // Debug.Log("Flee Enter", gameObject);
            GetComponentInParent<Rigidbody>().velocity = Vector3.up * 30;
            StartCoroutine(DelayExit(endDelay));
        }

        public override void Tick()
        {
            // Debug.Log("Flee Execute", gameObject);
        }

        public override void Exit()
        {           
            // Debug.Log("Flee Exit", gameObject);
            
            base.Exit();
        }
    }

}

