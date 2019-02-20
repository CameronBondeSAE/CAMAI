using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Russell
{
    public class DashExecute : AbilityBase
    {
        public CharacterBase _characterBase;
        public GameObject ai;
        public GameObject newTarget;
        private float backDistance = 5;
        
        private void Awake()
        {
            _characterBase = ai.GetComponent<CharacterBase>();
            ai.GetComponent<Kyllarr_Model>().KillMove += Kyllarr_Model_KillThatGuy;
        }

        private void Kyllarr_Model_KillThatGuy()
        {
            newTarget = _characterBase.Target;
            ai.transform.position = newTarget.transform.position - newTarget.transform.forward * backDistance;
            Debug.Log("you ded");
        }

        public override void Enter()
        {
            //Testing Teleport function
            base.Enter();
            
        }

        public override void Execute()
        {
            base.Execute();
        }

        public override void Exit()
        {
            base.Exit();


        }


    }
}