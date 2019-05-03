using UnityEngine;
using NodeCanvas.BehaviourTrees;

namespace Tegan
{
    public class AurielBehaviourTree : MonoBehaviour
    {
        private BehaviourTreeOwner aurielBehaviourTree;

        void Awake()
        {
            aurielBehaviourTree = GetComponent<BehaviourTreeOwner>();
        }

        public void NextMove()
        {
            aurielBehaviourTree.Tick();
        }
    }
}
