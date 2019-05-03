using System.Collections;
using UnityEditor.VersionControl;
using UnityEngine;

namespace Kennith
{
    public class StateBase : MonoBehaviour
    {

        public float endDelay = 3f;
        public string stateText;
        
        public virtual void Enter()
        {
            GetComponentInParent<CharacterBase>().debugText = stateText;
        }

        public virtual void Tick()
        {
        
        }

        public virtual void Exit()
        {
            StopAllCoroutines();
            GetComponentInParent<Kennith_Controller>().EvaluateNextMove();
        }

        public IEnumerator DelayExit(float time)
        {
            yield return new WaitForSeconds(time);
            Exit();
        }
    }

}

