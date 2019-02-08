using UnityEngine;
using UnityEngine.Serialization;

namespace Kennith
{
    
    public class Kennith_Model : CharacterBase
    {

        public StateBase spiritBombState;
        public StateBase moveState, fleeState, idleState;
        public StateBase currentState;

        public void ChangeState(StateBase newState)
        {
            if (currentState == newState) return;
            
            newState.Enter();
            currentState = newState;

        }

        private void Awake()
        {
            spiritBombState = GetComponent<SpiritBomb>();
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

