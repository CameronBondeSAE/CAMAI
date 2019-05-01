using UnityEngine;

namespace Kennith
{
    public class MoveState : StateBase
    {
        public Transform parent;
        private Kennith_Model model;
        private float dist;

        private Rigidbody body;

        public float speed;
        public float speedCap;

        public float rotationValue = 0;
        
        private void Awake()
        {
            model = GetComponentInParent<Kennith_Model>();
            dist = model.turningDistance;
            body = GetComponentInParent<Rigidbody>();
        }

        public override void Enter()
        {
            base.Enter();
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
            float smallestDist = Avoidance();

            body.AddForce(parent.forward * speed * smallestDist * model.SpeedMultiplier);
            body.AddRelativeTorque(Vector3.up * rotationValue * 250);

            body.angularVelocity = Vector3.Lerp(body.velocity, Vector3.zero, 0.02f);
            body.velocity = Vector3.Lerp(body.velocity, Vector3.zero, 0.02f);
            body.velocity = Vector3.ClampMagnitude(body.velocity, speedCap);
        }

        private float Avoidance()
        {
            Vector3 offset = parent.right;
            RaycastHit hit;
            float smallestDist = 9999999;
            bool hitSomething = false;

            rotationValue = 0;

            // forward
            if (Physics.Raycast(parent.position, parent.forward, out hit, dist))
            {
                Debug.DrawRay(parent.position, parent.forward, Color.red);
                rotationValue -= 14;
                hitSomething = true;
                
                if (hit.distance < smallestDist) smallestDist = hit.distance;
            }
            
            // right
            if (Physics.Raycast(parent.position, parent.forward + offset, out hit, dist))
            {
                Debug.DrawRay(parent.position, parent.forward, Color.white);
                rotationValue -= 3f;
                hitSomething = true;
                
                if (hit.distance < smallestDist) smallestDist = hit.distance;
            }
            
            // left
            if (Physics.Raycast(parent.position, parent.forward - offset, out hit, dist))
            {
                Debug.DrawRay(parent.position, parent.forward, Color.white);
                rotationValue += 3f;
                hitSomething = true;
                
                if (hit.distance < smallestDist) smallestDist = hit.distance;
            }

            if (!hitSomething) return dist;

            return smallestDist;

        }

        private void CalculateTurn(float input)
        {
            if (input < 0)
            {
                rotationValue += 1;
            }
            else
            {
                rotationValue -= 1;
            }

        }
        
        public override void Exit()
        {           
            // Debug.Log("Move Exit", gameObject);
            base.Exit();
        }
    }

}

