using NodeCanvas.BehaviourTrees;
using UnityEngine;

namespace Michael
{
    public class StateBase : MonoBehaviour
    {
        public string name;
        public float delay;
        public GameObject Self;
        
        private void Awake()
        {
            Self = GetComponentInParent<CharacterBase>().transform.gameObject;
        }

        public virtual void Enter()
        {
            Invoke("Exit", delay);
        }

        public virtual void Execute()
        {
            if (Self == null) CancelInvoke();
        }

        public virtual void Exit()
        {
            CancelInvoke();
            Self.GetComponentInChildren<BehaviourTreeOwner>().Tick();
        }
    }
}