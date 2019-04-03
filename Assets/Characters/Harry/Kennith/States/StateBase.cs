using System.Collections;
using UnityEngine;

namespace Kennith
{
    public class StateBase : MonoBehaviour
    {

        public float endDelay = 3f;
        
        public virtual void Enter()
        {
        
        }

        public virtual void Tick()
        {
        
        }

        public virtual void Exit()
        {
            GetComponentInParent<Kennith_Controller>().EvaluateNextMove();
        }

        public IEnumerator DelayExit(float time)
        {
            yield return new WaitForSeconds(time);
            Exit();
        }
    }

}

