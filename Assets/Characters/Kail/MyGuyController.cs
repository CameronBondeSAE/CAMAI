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
        public StateBase deathState;

        public GameObject myTarget;
        public int next;

        public Health healthBase;
        public float health;
        
        public void Awake()
        {
            
            
            //set everything up
            tauntState = GetComponent<TauntState>();
            idleState = GetComponent<IdleState>();
            runState = GetComponent<RunState>();
            healthBase = GetComponent<Health>();

            health = healthBase.Amount;
            
            


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
                    break;
                case 1:
                    newState = tauntState;
                    break;
                case 2:
                    newState = runState;
                    break;
                case 3:
                    newState = deathState;
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

        

    }
}