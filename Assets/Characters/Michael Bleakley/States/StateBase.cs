using NodeCanvas.BehaviourTrees;
using UnityEngine;

namespace Michael
{
    public class StateBase : MonoBehaviour
    {
        public float delay;
        public GameObject Self;

        public virtual void Enter()
        {
            Invoke("Exit", delay);
        }

        public virtual void Execute()
        {

        }

        public virtual void Exit()
        {
            CancelInvoke();
            Self.GetComponentInChildren<BehaviourTreeOwner>().Tick();
        }
    }
}