using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace Michael
{
    public class AttackState : StateBase
    {
        
        public override void Enter()
        {
            Debug.Log("West");
            base.Enter();
            Destroy( Self.GetComponent<CharacterBase>().Target);
            //print("Entry of Attack");
        }

        public override void Execute()
        {
            /*
             * check distance from target
             * check if any abilities are usable
             * Move if out of range
             * when in range use ability
             */
            base.Execute();
            //print("Attacking");
        }

        public override void Exit()
        {
            Self.GetComponent<CharacterBase>().Target = null;
            base.Exit();
            //print("Exit of attack");
        }
    }
}
