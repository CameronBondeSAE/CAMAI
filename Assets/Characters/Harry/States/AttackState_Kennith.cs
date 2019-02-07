using UnityEngine;

namespace Kennith
{
    public class AttackState_Kennith : StateBase_Kennith
    {
        public override void Enter()
        {
            base.Enter();
            
            Debug.Log("Attack Enter", gameObject);
        }

        public override void Execute()
        {
            base.Execute();
            
            Debug.Log("Attack Update", gameObject);
        }

        public override void Exit()
        {
            base.Exit();
            
            Debug.Log("Attack Exit", gameObject);
        }
    }

}

