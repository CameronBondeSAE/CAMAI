using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Michael
{
    public class Darkling_Model : CharacterBase
    {
        public StateBase currentState;
        public bool enemySeen;
        public float distance;
        private GameObject[] friends;
        [SerializeField] private Rigidbody rb;
        public float time;

        [SerializeField] private float turningVariable;

        public GameObject vestraLead;

        [SerializeField] private GameObject vestraOrigin;
        // Start is called before the first frame update

        public override void Start()
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
            vestraLead.GetComponentInChildren<SpawnState>().darklings.Remove(gameObject);
            Destroy(gameObject);
        }

        private void OnHurtEvent()
        {
        }

        public void ChangeState(StateBase newState)
        {
            newState.Enter();
            currentState = newState;
            debugText = currentState.name;
        }

        public void OverrideState()
        {
            enemySeen = Target != null;
            if (currentState != null) currentState.Exit();
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            if (currentState != null) currentState.Execute();
      
            if (transform.position.y < -5)
            {
                if (vestraLead != null) vestraLead.GetComponentInChildren<SpawnState>().darklings.Remove(gameObject);
                Destroy(gameObject);
            }

            enemySeen = Target != null;
            if (vestraLead != null)
            {
                distance = Vector3.Distance(transform.position, vestraLead.transform.position);
            }
            else
            {
                distance = 0;
                if (time > 0)
                {
                    time -= Time.fixedDeltaTime;
                }
                else
                {
                    Instantiate(vestraOrigin, this.transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
            }
        }

        public override void Move(Vector3 speedDirection)
        {
            
            var targetPosition = transform.InverseTransformPoint(speedDirection);
            var temp = targetPosition.x / targetPosition.magnitude;
            if (rb != null) rb.AddRelativeTorque(0, turningVariable * 0.5f * temp * distance, 0);

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 2.3f))
            {
                if (rb != null)
                {
                    rb.AddRelativeTorque(0, turningVariable * 3f  * distance, 0);
                    rb.AddRelativeForce(-Vector3.forward * (SpeedMultiplier * 0.5f), ForceMode.Force);
                }
            }
            else
            {
                if (rb != null) rb.AddRelativeForce(Vector3.forward * SpeedMultiplier, ForceMode.Force);
            }

            if (Physics.Raycast(transform.position, transform.forward + transform.right, out hit, 2f))
            {
                if (rb != null)
                {
                    rb.AddRelativeTorque(0, -turningVariable * 1.5f  * distance, 0);
                    rb.AddRelativeForce(-Vector3.forward * (SpeedMultiplier * 0.5f), ForceMode.Force);
                }
            }


            if (Physics.Raycast(transform.position, transform.forward - transform.right, out hit, 2f))
            {
                if (rb != null)
                {
                    rb.AddRelativeTorque(0, turningVariable * 1.5f  * distance, 0);
                    rb.AddRelativeForce(-Vector3.forward * (SpeedMultiplier * 0.5f), ForceMode.Force);
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.gameObject.GetComponent<CharacterBase>())
            {
                if (other.transform.gameObject.GetComponent<Vestra_Model>()) return;
                if (other.transform.gameObject.GetComponent<Darkling_Model>()) return;
                Target = other.gameObject;
                OverrideState();
            }
        }

        /*
         * Abilities:
         *     Magic Missle limited
         *     Changed: Channel Devistation : a concentrated "beam" at the target
         *              Constant Area of effect damage
         *     Reformation : when a great number of of darklings are in proximity they join to make a vestra.
         *
         * Movement:
         * flock mentality and follow vestra if vestra is not there flock randomly until another is found or they die.
         */
    }
}