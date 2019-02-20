using NodeCanvas.BehaviourTrees;
using UnityEngine;

namespace Michael
{
    public class StateBase : MonoBehaviour
    {
        public float delay;

        public virtual void Enter()
        {
            Invoke("Exit", delay);
        }

        public virtual void Execute()
        {

        }

        public virtual void Exit()
        {
            GetComponent<BehaviourTreeOwner>().Tick();
            CancelInvoke();
        }
    }
}