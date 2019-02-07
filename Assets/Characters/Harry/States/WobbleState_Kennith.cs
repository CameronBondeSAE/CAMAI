using UnityEngine;

namespace Kennith
{
    public class WobbleState_Kennith : StateBase_Kennith
    {
        public override void Enter()
        {
            base.Enter();
            
            Debug.Log("Wobble Start", gameObject);
        }

        public override void Execute()
        {
            base.Execute();
            
            Debug.Log("Wobble Update", gameObject);
        }

        public override void Exit()
        {
            base.Exit(); 
            
            Debug.Log("Wobble Exit", gameObject);
        }
    }

}

