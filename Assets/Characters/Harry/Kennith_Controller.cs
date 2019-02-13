using NodeCanvas.BehaviourTrees;
using NodeCanvas.Tasks.Actions;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Kennith
{
    public class Kennith_Controller : MonoBehaviour
    {

        public Kennith_Model kennith;

        private void Awake()
        {
            kennith = GetComponent<Kennith_Model>();
        }

        public void EvaluateNextMove()
        {
            
            GetComponent<BehaviourTreeOwner>().Tick();
            
//            if (kennith.currentState == kennith.spiritBombState) kennith.ChangeState(kennith.moveState); 
//            else if (kennith.currentState == kennith.moveState) kennith.ChangeState(kennith.fleeState); 
//            else if (kennith.currentState == kennith.fleeState) kennith.ChangeState(kennith.idleState); 
//            else if (kennith.currentState == kennith.idleState) kennith.ChangeState(kennith.spiritBombState);
        }
        
    }
    
}
