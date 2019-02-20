using UnityEngine;

namespace Kennith
{
    public class MoveState : StateBase
    {
        private Transform parent;
        private float dist;

        private void Awake()
        {
            parent = GetComponentInParent<Transform>();
            dist = GetComponentInParent<Kennith_Model>().turningDistance;
        }

        public override void Enter()
        {
            StartCoroutine(DelayExit(endDelay));
            Debug.Log("Move Enter", gameObject);
        }

        public override void Tick()
        {
            GetComponentInParent<Rigidbody>().velocity = transform.forward * 4;
            Debug.Log("Move Execute", gameObject);
        }

        private void AvoidanceLeft()
        {

            
        }

        private void AvoidanceRight()
        {
            
        }
        
        public override void Exit()
        {           
            Debug.Log("Move Exit", gameObject);
            base.Exit();
        }
    }

}

