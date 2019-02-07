using UnityEngine;

namespace Cam
{
    public class AttackState : StateBase
    {
        public override void Enter()
        {
            base.Enter();

            Debug.Log("AttackEnter");
            
            GetComponent<Renderer>().material.color = Color.red;
        }

        public override void Execute()
        {
            base.Execute();
            Debug.Log("AttackUpdate");
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("AttackExit");
            GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
