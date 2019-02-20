using UnityEngine;

namespace Kennith
{
    
    public class Kennith_Model : CharacterBase
    {

        public StateBase spiritBombState;
        public StateBase moveState, fleeState, idleState;
        public StateBase currentState;
        
        public double visionRange;
        public double visionAngle;

        public GameObject TargetObject;
    

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
            
            currentState = idleState;
            currentState.Enter();
        }

        private void Update()
        {
            currentState.Tick();
            
            //TESTING
            CheckFor(TargetObject);
        }
        
        public bool CheckFor(GameObject other) // returns true/false if object inserted is visible
        {
            float magnitudeTo = Vector3.Distance(transform.position, other.transform.position);
            
            if (magnitudeTo > visionRange) return false;

            Vector3 targetDir = other.transform.position - transform.position; // correcting object's location relative to us
            if (Vector3.Angle(targetDir, transform.forward) > (visionAngle / 2)) return false;

            if (!CheckBounds(other)) return false;

            Debug.Log("I CAN SEE THE TARGET");
            
            return true;

        }

        // NEEDS TO BE OPTIMISED
        private bool CheckBounds(GameObject other)
        {
            Collider col = other.GetComponent<Collider>();
            Vector3 ext = col.bounds.extents;

            if (col == null) return false;

            Vector3 v2, v3, v4, v5, v6, v7, v8, v9;
            bool r1 = false, r2 = false, r3 = false, r4 = false, r5 = false, r6 = false, r7 = false, r8 = false, r9 = false;

            RaycastHit hit;

            if (Physics.Linecast(transform.position + Vector3.up * 2, other.transform.position, out hit) &&
                hit.transform.gameObject == other)
            {
                r1 = true;
                Debug.DrawLine(transform.position, other.transform.position, Color.magenta);
            }
            
            
            v2 = other.transform.TransformPoint(ext.x, ext.y, ext.z);
            v2 = col.ClosestPoint(v2);
            if (Physics.Linecast(transform.position + Vector3.up * 2, v2, out hit) &&
                hit.transform.gameObject == other)
            {
                r2 = true;
                Debug.DrawLine(transform.position, v2, Color.magenta);
            }
            
            
            v3 = other.transform.TransformPoint(-ext.x, ext.y, ext.z);
            v3 = col.ClosestPoint(v3);
            if (Physics.Linecast(transform.position + Vector3.up * 2, v3, out hit) &&
                hit.transform.gameObject == other)
            {
                r3 = true;
                Debug.DrawLine(transform.position, v3, Color.magenta);
            }
            
            
            v4 = other.transform.TransformPoint(ext.x, -ext.y, -ext.z);
            v4 = col.ClosestPoint(v4);
            if (Physics.Linecast(transform.position + Vector3.up * 2, v4, out hit) &&
                hit.transform.gameObject == other)
            {
                r4 = true;
                Debug.DrawLine(transform.position, v4, Color.magenta);
            }
            
            
            v5 = other.transform.TransformPoint(-ext.x, -ext.y, -ext.z);
            v5 = col.ClosestPoint(v5);
            if (Physics.Linecast(transform.position + Vector3.up * 2, v5, out hit) &&
                hit.transform.gameObject == other)
            {
                r5 = true;
                Debug.DrawLine(transform.position, v5, Color.magenta);
            }


            v6 = other.transform.TransformPoint(ext.x, ext.y, ext.z);
            v6 = col.ClosestPoint(v6);
            if (Physics.Linecast(transform.position + Vector3.up * 2, v6, out hit) &&
                hit.transform.gameObject == other)
            {
                r5 = true;
                Debug.DrawLine(transform.position, v5, Color.magenta);
            }
            
            
            v7 = other.transform.TransformPoint(ext.x, ext.y, -ext.z);
            v7 = col.ClosestPoint(v7);
            if (Physics.Linecast(transform.position + Vector3.up * 2, v7, out hit) &&
                hit.transform.gameObject == other)
            {
                r7 = true;
                Debug.DrawLine(transform.position, v7, Color.magenta);
            }
            
            
            v8 = other.transform.TransformPoint(-ext.x, -ext.y, ext.z);
            v8 = col.ClosestPoint(v8);
            if (Physics.Linecast(transform.position + Vector3.up * 2, v8, out hit) &&
                hit.transform.gameObject == other)
            {
                r8 = true;
                Debug.DrawLine(transform.position, v8, Color.magenta);
            }
            
            
            v9 = other.transform.TransformPoint(-ext.x, -ext.y, -ext.z);
            v9 = col.ClosestPoint(v9);
            if (Physics.Linecast(transform.position + Vector3.up * 2, v9, out hit) &&
                hit.transform.gameObject == other)
            {
                r9 = true;
                Debug.DrawLine(transform.position, v9, Color.magenta);
            }
            
            if (r1 || r2 || r3 || r4 || r5 || r6 || r7 || r8 || r9)
            {
                return true;
            }

            return false;
        }
        
    }
    
}

