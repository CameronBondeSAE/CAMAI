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

            if (Physics.Raycast(parent.position, parent.forward, out hit, 1))
            {
                Debug.DrawRay(parent.position, parent.forward, Color.red);
                rotationValue = 10;
                return rotationValue;
            }
            
            for (int i = -5; i < 6; i++)
            {
                
                if (Physics.Raycast(parent.position, parent.forward + offset, out hit, dist))
                {
                    hitSomething = true;
                    Debug.DrawLine(parent.position, hit.point);
                    CalculateTurn(offset.x);
                }
                

                if (hit.distance < smallestDist)
                {
                    smallestDist = hit.distance;
                }
                
                Debug.DrawRay(parent.position, parent.forward + offset);
                offset -= parent.right * 0.2f;
            }

            if (!hitSomething)
            {
                return dist;
            }
            else
            {
                return smallestDist;
            }
            
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

