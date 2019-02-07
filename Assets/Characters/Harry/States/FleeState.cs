using UnityEngine;

namespace Kennith
{
    public class FleeState : StateBase
    {
        public override void Enter()
        {
            base.Enter();
            
            Debug.Log("Flee Enter", gameObject);
        }

        public override void Execute()
        {
            base.Execute();
            
            Debug.Log("Flee Execute", gameObject);
        }

        public override void Exit()
        {
            base.Exit();
            
            Debug.Log("Flee Exit", gameObject);
        }
    }

}

