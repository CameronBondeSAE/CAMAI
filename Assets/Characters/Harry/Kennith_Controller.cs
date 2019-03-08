using NodeCanvas.BehaviourTrees;
using NodeCanvas.Tasks.Actions;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Kennith
{
    public class Kennith_Controller : MonoBehaviour
    {
        private BehaviourTreeOwner tree;

        private void Awake()
        {
            tree = GetComponent<BehaviourTreeOwner>();
        }

        public void EvaluateNextMove()
        {         
            tree.Tick();
        }
        
    }
    
}
