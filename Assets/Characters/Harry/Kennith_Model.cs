using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

namespace Kennith
{
    
    public class Kennith_Model : CharacterBase
    {

        public StateBase attackState, moveState, fleeState, idleState;
        public StateBase currentState;

        public void ChangeState(StateBase newState)
        {
            if (currentState == newState) return;
            
            newState.Enter();
            currentState = newState;

        }

        private void Awake()
        {
            attackState = GetComponent<AttackState>();
            moveState = GetComponent<MoveState>();
            fleeState = GetComponent<FleeState>();
            idleState = GetComponent<IdleState>();
            
            currentState = idleState;
            currentState.Enter();
        }

        private void Update()
        {
            // Hacking/Testing
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Kennith_Controller>().EvaluateNextMove();
                Debug.Log("input down");
            }
            
            currentState.Execute();
        }
        
    }
    
}

