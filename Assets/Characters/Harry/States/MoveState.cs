using UnityEngine;

namespace Kennith
{
    public class MoveState : StateBase
    {
        public override void Enter()
        {
            StartCoroutine(DelayExit(endDelay));
            Debug.Log("Move Enter", gameObject);
        }

        public override void Tick()
        {
            GetComponentInParent<Rigidbody>().velocity = transform.forward * 4;
            Debug.Log("Move Execute", gameObject);
        }

        public override void Exit()
        {           
            Debug.Log("Move Exit", gameObject);
            base.Exit();
        }
    }

}

