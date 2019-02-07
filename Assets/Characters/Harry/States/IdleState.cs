using UnityEngine;

namespace Kennith
{
    public class IdleState : StateBase
    {
        public override void Enter()
        {
            base.Enter();
            
            Debug.Log("Idle Enter", gameObject);
        }

        public override void Execute()
        {
            base.Execute();
            
            Debug.Log("Idle Execute", gameObject);
        }

        public override void Exit()
        {
            base.Exit();
            
            Debug.Log("Idle Exit", gameObject);
        }
    }

}

