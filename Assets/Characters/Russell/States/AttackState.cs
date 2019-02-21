
using System;
using UnityEngine;


namespace Russell
{
    public class AttackState : StateBase
    {
        public Rigidbody obj;
        public Transform location;
        private CharacterBase _characterBase;

        private void Awake()
        {
            _characterBase = transform.GetComponent<CharacterBase>();
        }

        public override void Enter()
        {
            base.Enter();            
        }

        public override void Execute()
        {
            base.Execute();
            if (!_characterBase.Target == null)
            {
                
            }
            transform.position = transform.forward * 10 * Time.deltaTime;
        }

        public override void Exit()
        {
            base.Exit();
        }
    }


}
