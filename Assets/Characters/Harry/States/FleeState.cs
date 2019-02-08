using UnityEngine;

namespace Kennith
{
    public class FleeState : StateBase
    {
        public override void Enter()
        {
            base.Enter();
            
            Debug.Log("Flee Enter", gameObject);
            GetComponent<Rigidbody>().velocity = Vector3.up * 30;
            Invoke("Exit", 3f);
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

