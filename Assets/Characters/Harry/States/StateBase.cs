using UnityEngine;

namespace Kennith
{
    public class StateBase : MonoBehaviour
    {
        public virtual void Enter()
        {
        
        }

        public virtual void Execute()
        {
        
        }

        public virtual void Exit()
        {
            GetComponent<Kennith_Controller>().EvaluateNextMove();
        }
    }

}

