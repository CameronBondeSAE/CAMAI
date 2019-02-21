using UnityEngine;

namespace Kennith
{
    public class MoveState : StateBase
    {
        private Transform parent;
        private Kennith_Model model;
        private float dist;

        private Rigidbody body;

        public float speed;

        public bool objectLeft, objectRight;
        
        private void Awake()
        {
            model = GetComponentInParent<Kennith_Model>();
            parent = GetComponentInParent<Transform>();
            dist = model.turningDistance;
            body = GetComponentInParent<Rigidbody>();
        }

        public override void Enter()
        {
            StartCoroutine(DelayExit(endDelay));
            // Debug.Log("Move Enter", gameObject);
        }

        public override void Tick()
        {
            Move();
            // Debug.Log("Move Execute", gameObject);
        }

        private void Move() 
        {
            body.AddForce(parent.forward * speed * model.SpeedMultiplier);
        }

        private void AvoidanceLeft()
        {
            
        }

        private void AvoidanceRight()
        {
            
        }
        
        public override void Exit()
        {           
            // Debug.Log("Move Exit", gameObject);
            base.Exit();
        }
    }

}

