using UnityEngine;

namespace Michael
{
    public class FleeState : StateBase
    {
        public GameObject target;
        public override void Enter()
        {
            target = Self.GetComponent<CharacterBase>().Target;
        }

        public override void Execute()
        {
            base.Execute();
            if (Vector3.Distance(transform.position, target.transform.position) > 40) Exit();
            Vector3 temp = -target.transform.position + transform.position;
            temp.y = 1;
            Self.GetComponent<Vestra_Model>().Move(temp);
            /*
             * get threat locations and move away from them
             * or get one threat / the main target and move away
             */
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}