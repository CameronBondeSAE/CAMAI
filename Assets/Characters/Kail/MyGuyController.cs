using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kail
{
    
    public class MyGuyController : CharacterBase
    {

        public StateBase currentState;
        public StateBase tauntState;
        public StateBase idleState;
        public StateBase runState;

        public GameObject myTarget;
        
        public void ChangeState(StateBase newState)
        {

            if (currentState == newState) return;
            
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
            //currentState.Enter();

        }

    }
}