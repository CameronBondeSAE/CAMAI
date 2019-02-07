
using UnityEngine;


namespace Russell
{
    public class AttackState : StateBase
    {
        public Rigidbody obj;
        public Transform location;
        
        public override void Enter()
        {
            base.Enter();
            Rigidbody projectileLaunch;
            projectileLaunch = Instantiate(obj, location.position, location.rotation) as Rigidbody;
            projectileLaunch.AddForce(location.forward * 100);
            Debug.Log(("AttackStart", gameObject));
        }

        public override void Execute()
        {
            base.Execute();
            Debug.Log(("AttackExecute", gameObject));
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log(("AttackExit", gameObject));
        }
    }


}
