using UnityEngine;

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
            if (kennith.currentState == kennith.attackState) kennith.ChangeState(kennith.moveState); 
            else if (kennith.currentState == kennith.moveState) kennith.ChangeState(kennith.fleeState); 
            else if (kennith.currentState == kennith.fleeState) kennith.ChangeState(kennith.idleState); 
            else if (kennith.currentState == kennith.idleState) kennith.ChangeState(kennith.attackState); 
        }
        
    }

}
