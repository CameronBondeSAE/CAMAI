using UnityEngine;

namespace Michael
{
    public class AttackState : StateBase
    {
        private GameObject target;

        public override void Enter()
        {
            base.Enter();
            print("Entry of Attack");
        }

        public override void Execute()
        {
            base.Execute();
            print("Attacking");
        }

        public override void Exit()
        {
            base.Exit();
            print("Exit of attack");
        }
    }
}
