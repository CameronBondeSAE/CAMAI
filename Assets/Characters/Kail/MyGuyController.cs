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
        
        public void ChangeState(int state)
        {

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

            }
            
            //go to currentState exit, then newState Enter, then set the new state
            currentState.Exit();
            //note - makes sure currentState exits pre newState starting
            newState.Enter();
            currentState = newState;
        }
        
        
        public void Awake()
        {
            //set everything up
            tauntState = GetComponent<TauntState>();
            idleState = GetComponent<IdleState>();
            runState = GetComponent<RunState>();

            currentState = idleState;
            currentState.Enter();

        }

    }
}