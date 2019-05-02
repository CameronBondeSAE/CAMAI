using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kail
{
    
    public class MyGuyController : CharacterBase
    {

        public StateBase currentState;
        public StateBase newState;
        public StateBase tauntState;
        public StateBase idleState;
        public StateBase runState;

        public GameObject myTarget;
        public int next;

        public Health healthBase;
        //public float health;
        
        public void Awake()
        {
            characterName = "myGuy";
            
            //set everything up
            tauntState = GetComponent<TauntState>();
            idleState = GetComponent<IdleState>();
            runState = GetComponent<RunState>();
            healthBase = GetComponent<Health>();

            //health = healthBase.Amount;

            healthBase.maxAmount = 100;
            healthBase.OnDeathEvent += Die;

            currentState = idleState;
            currentState.Enter();
            
            

        }
        public void ChangeState()
        {
            //go to currentState exit, then newState Enter, then set the new state
            currentState.Exit(next);
            //note - makes sure currentState exits pre newState starting
            newState.Enter();
            currentState = newState;
        }

        public void SetState(int state)
        {

            next = state;
            
            switch (state)
            {
                case 0:
                    newState = idleState;
                    debugText = "idle";
                    break;
                case 1:
                    newState = tauntState;
                    debugText = "taunting";
                    break;
                case 2:
                    newState = runState;
                    debugText = "running";
                    break;

            }

            if (newState == currentState)
            {
                //do nothing
            }

            else
            {
                ChangeState();
            }
            
        }

        public void Die()
        {
            Destroy(this.gameObject);
        }

        private void Update()
        {
            if (currentState == tauntState)
            {
                if (myTarget = null)
                {
                    SetState(0);
                }
            }
        }
    }
}