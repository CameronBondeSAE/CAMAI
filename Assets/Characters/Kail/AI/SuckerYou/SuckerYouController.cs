using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kail
{

    public class SuckerYouController : CharacterBase
    {
        //a record of the states this character has
        private StateBase[] syStates;
        public string[] statesTxt;
        
        private StateBase idleState;
        private StateBase attackState;
        private StateBase chaseState;
        private StateBase runState;

        public GameObject target;
        public bool targetFound;

        //used for swapping and recording states
        public StateBase currentState;
        
        //for setting the health
        public Health healthBase;

        private void Awake()
        {
            characterName = "SuckerYou";
            
            //collect all the things
            idleState = GetComponentInChildren<SY_IdleState>();
            attackState = GetComponentInChildren<SY_AttackState>();
            chaseState = GetComponentInChildren<SY_ChaseState>();
            runState = GetComponentInChildren<SY_RunState>();
            healthBase = GetComponent<Health>();

            //put them into the syStates array
            syStates = new StateBase[4] {idleState, attackState, chaseState, runState};
            statesTxt = new string[4] {"idle", "attacking", "chasing", "running"};
            //set health
            healthBase.maxAmount = 100;
            
            currentState = idleState;
            currentState.Enter();
        }

        public void ChangeState(int next)
        {
            //finish old state
            currentState.Exit(next);
            //set current state as the new state, then start the new state
            currentState = syStates[next];
            debugText = statesTxt[next];
            currentState.Enter();
        }
        

    }
}