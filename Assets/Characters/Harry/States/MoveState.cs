using UnityEngine;

namespace Kennith
{
    public class MoveState : StateBase
    {
        public override void Enter()
        {
            base.Enter();
            
            Debug.Log("Move Enter", gameObject);
        }

        public override void Execute()
        {
            base.Execute();
            
            Debug.Log("Move Execute", gameObject);
        }

        public override void Exit()
        {
            base.Exit();
            
            Debug.Log("Move Exit", gameObject);
        }
    }

}

