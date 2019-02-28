using UnityEngine;

namespace Kennith
{
    
    public class Kennith_Model : CharacterBase
    {
        [HideInInspector]
        public StateBase spiritBombState, moveState, fleeState, idleState, deathState, hailState;
        
        public StateBase currentState;
        
        public double visionRange;
        public double visionAngle;

        public GameObject TargetObject;
        public float turningDistance;


        public void ChangeState(StateBase newState)
        {
           // if (currentState == newState) return;
            
            newState.Enter();
            currentState = newState;

        }

        private void Awake()
        {
            spiritBombState = GetComponentInChildren<SpiritBomb>();
            moveState = GetComponentInChildren<MoveState>();
            fleeState = GetComponentInChildren<FleeState>();
            idleState = GetComponentInChildren<IdleState>();
            deathState = GetComponentInChildren<DeathState>();
            hailState = GetComponentInChildren<HailAttack>();
            
            currentState = moveState;
            currentState.Enter();

            GetComponent<Health>().OnDeathEvent += Perish;
        }

        private void Update()
        {
            currentState.Tick();
            
            //TESTING
            if (TargetObject != null) CheckFor(TargetObject);
        }
        
        public bool CheckFor(GameObject other) // returns true/false if object inserted is visible
        {
            float magnitudeTo = Vector3.Distance(transform.position, other.transform.position);
            
            if (magnitudeTo > visionRange) return false;

            Vector3 targetDir = other.transform.position - transform.position; // correcting object's location relative to us
            if (Vector3.Angle(targetDir, transform.forward) > (visionAngle / 2)) return false;

            if (!CheckBounds(other)) return false;

            // Debug.Log("I CAN SEE THE TARGET");
            
            return true;

        }

        private bool ThrowRay(GameObject obj, Collider col, float x, float y, float z)
        {
            Vector3 v;
            RaycastHit hit;
            bool b = false;
            
            v = obj.transform.TransformPoint(x, y, z);
            v = col.ClosestPoint(v);
            if (Physics.Linecast(transform.position + Vector3.up * 2, v, out hit) && hit.transform.gameObject == obj)
            {
                b = true;
                Debug.DrawLine(transform.position, v, Color.magenta);
            }

            return b;
        }
        
        // NEEDS TO BE OPTIMISED
        private bool CheckBounds(GameObject other)
        {
            Collider col = other.GetComponent<Collider>();
            Vector3 ext = col.bounds.extents;

            if (col == null) return false;

            bool r1 = false, r2 = false, r3 = false, r4 = false, r5 = false, r6 = false, r7 = false, r8 = false, r9 = false;

            r1 = ThrowRay(other, col, 0,0,0);
            r2 = ThrowRay(other, col, ext.x, ext.y, ext.z);
            r3 = ThrowRay(other, col, -ext.x, ext.y, ext.z);
            r4 = ThrowRay(other, col, ext.x, -ext.y, -ext.z);
            r5 = ThrowRay(other, col, -ext.x, -ext.y, -ext.z);
            r6 = ThrowRay(other, col, ext.x, ext.y, ext.z);
            r7 = ThrowRay(other, col, ext.x, ext.y, -ext.z);
            r8 = ThrowRay(other, col, -ext.x, -ext.y, ext.z);
            r9 = ThrowRay(other, col, -ext.x, -ext.y, -ext.z);

            if (r1 || r2 || r3 || r4 || r5 || r6 || r7 || r8 || r9)
            {
                return true;
            }

            return false;
        }

        public void Perish()
        {
           ChangeState(deathState);
        }
    }
    
}

