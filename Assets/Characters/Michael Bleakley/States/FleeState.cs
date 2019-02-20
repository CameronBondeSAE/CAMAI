using UnityEngine;

namespace Michael
{
    public class FleeState : StateBase
    {
        private GameObject temp;
        public override void Enter()
        {
            base.Enter();
            print("Entry of Flee");
        }

        public override void Execute()
        {
            base.Execute();
            /*
             * get threat locations and move away from them
             * or get one threat / the main target and move away
             */
            temp = GetComponent<Vestra_Model>().Target;
            GetComponent<Vestra_Model>().Move(new Vector3((transform.position.x + transform.position.x - temp.transform.position.x),(transform.position.y + transform.position.y - temp.transform.position.y),(transform.position.z + transform.position.z- temp.transform.position.z)));
            print("Fleeing");
        }

        public override void Exit()
        {
            base.Exit();
            print("Exit of Flee");
        }
    }
}