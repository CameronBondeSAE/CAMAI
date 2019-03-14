using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Michael
{
    public class Darkling_Model : CharacterBase
    {
        
        public StateBase currentState;
        private GameObject vestraLead;
        private GameObject[] friends;

        [SerializeField] private float turningVariable;
        [SerializeField] private Rigidbody rb;
        // Start is called before the first frame update
        void Start()
        {
            base.Start();
            GetComponent<Health>().OnHurtEvent += OnHurtEvent;
            GetComponent<Health>().OnDeathEvent += OnDeathEvent;
            GetComponent<Energy>().OnReducingEvent += OnReducingEvent;
        }

        private void OnReducingEvent()
        {
            currentState.Exit();
        }

        private void OnDeathEvent()
        {
            Destroy(gameObject);
        }

        private void OnHurtEvent()
        {
            
        }

        public void ChangeState(StateBase newState)
        {
            newState.Enter();
            currentState = newState;
        }
        // Update is called once per frame
        void FixedUpdate()
        {

        }

        public void Movement(Vector3 Destination)
        {
            if (rb != null) rb.AddRelativeForce(Vector3.forward * SpeedMultiplier, ForceMode.Force);

            var targetPosition = transform.InverseTransformPoint(Destination);
            var temp = targetPosition.x / targetPosition.magnitude;
            if (rb != null) rb.AddRelativeTorque(0, turningVariable * 0.5f * temp, 0);

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 1.3f))
            {
                Debug.DrawLine(transform.position, hit.point, Color.red, 1f);
                if (rb != null) rb.AddRelativeTorque(0, turningVariable * 2f, 0);
                


                /*
                if (Random.Range(-1, 1) < 0)
                {
                    rb.AddRelativeTorque(0, vary * -1, 0);
                }
                else
                {
                    rb.AddRelativeTorque(0, vary, 0);
                }
                */
            }

            if (Physics.Raycast(transform.position, transform.forward + transform.right, out hit, 1f))
            {
                if (rb != null) rb.AddRelativeTorque(0, -turningVariable * 1.5f, 0);
            }

            if (Physics.Raycast(transform.position, transform.forward - transform.right, out hit, 1f))
            {
                if (rb != null) rb.AddRelativeTorque(0, turningVariable * 1.5f, 0);
            }

        }
        /*
         * Abilities:
         *     Magic Missle limited
         *     Channel Devistation : a concentrated "beam" at the target
         *     Reformation : when a great number of of darklings are in proximity they join to make a vestra.
         *
         * Movement:
         * flock mentality and follow vestra if vestra is not there flock randomly until another is found or they die.
         */
    }
}
