
using System;
using System.Collections;
using UnityEngine;


namespace Russell
{
    public class AttackState : StateBase
    {
        public Kyllarr_Model _characterBase;

        private void Awake()
        {
            
        }

        public override void Enter()
        {
            base.Enter();
            StartCoroutine(changetoPartol());
        }

        public override void Execute()
        {
            base.Execute();

        }

        public override void Exit()
        {
            base.Exit();
        }

        IEnumerator changetoPartol()
        {
            yield return new WaitForSeconds(3);
            _characterBase.ChangeState(_characterBase.patrolState);
        }
    }


}
