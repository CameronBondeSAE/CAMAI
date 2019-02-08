using UnityEngine;

namespace Kennith
{
    public class MoveState : StateBase
    {
        public override void Enter()
        {
            base.Enter();
            Invoke("Exit", 3f);
            Debug.Log("Move Enter", gameObject);
        }

        public override void Execute()
        {
            base.Execute();
            GetComponent<Rigidbody>().velocity = transform.forward * 4;
            Debug.Log("Move Execute", gameObject);
        }

        public override void Exit()
        {
            base.Exit();
            
            Debug.Log("Move Exit", gameObject);
        }
    }

}

