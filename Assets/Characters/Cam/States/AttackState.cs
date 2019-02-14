using System;
using System.Collections;
using UnityEngine;

namespace Cam
{
    public class AttackState : StateBase
    {
        public MrDudes_Model _mrDudesModel;

        public event Action OnAttack;

        
        public override void Enter()
        {
            base.Enter();

            StartCoroutine("AttackCoroutine");
        }

        public override void Execute()
        {
            base.Execute();
        }

        public IEnumerator AttackCoroutine()
        {
            if (GameManager.Instance.CharacterBases.Count > 0)
            {
                _mrDudesModel.Target = GameManager.Instance.CharacterBases[0].gameObject;
            }

            OnAttack?.Invoke();

            yield return new WaitForSeconds(2);
            _mrDudesModel.EndState();
        }

        public override void Exit()
        {
            base.Exit();
//            GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
