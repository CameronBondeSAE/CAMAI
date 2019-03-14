using System.Collections.Generic;
using System.Linq;
using NodeCanvas.BehaviourTrees;
using UnityEngine;

namespace Michael
{
    public class Vestra_Model : CharacterBase
    {
        public bool enemySeen;
        public Rigidbody rb;
        public bool falling;
        public bool fleeing;
        //private GameObject[] surroundingEnemies;
        //private List<GameObject> surroundingEnemies;
        [SerializeField] private VestraTargeting _targeting;

        public override void Start()
        {
            base.Start();
            GetComponent<Health>().OnHurtEvent += OnHurtEvent;
            GetComponent<Health>().OnDeathEvent += OnDeathEvent;
            GetComponent<Energy>().OnReducingEvent += OnReducingEvent;
        }

        private void FixedUpdate()
        {
            if (currentState != null) currentState.Execute();
            falling = transform.position.y < -5;
            enemySeen = Target != null;
            
           
            /* test code
            if (Input.GetKeyDown(KeyCode.A)) ChangeState(fleeState);
            if (Input.GetKeyDown(KeyCode.S)) ChangeState(attackState);
            if (Input.GetKeyDown(KeyCode.D)) ChangeState(roamState);
            if (Input.GetKeyDown(KeyCode.Z)) GetComponent<BehaviourTreeOwner>().Tick();
            */
//          OverrideState();
        }

        #region Energy

        private void OnReducingEvent()
        {
            currentState.Exit();
        }

        #endregion

        public override void Move(Vector3 speedDirection)
        {
            /*
            * add force forward
            * add turning to direction wanted
            * detect collision on sides with ray cast and front to determine turning to avoid obsticles and slowing down speed
            */
            if (rb != null) rb.AddRelativeForce(Vector3.forward * SpeedMultiplier, ForceMode.Force);

            var targetPosition = transform.InverseTransformPoint(speedDirection);
            var temp = targetPosition.x / targetPosition.magnitude;
            if (rb != null) rb.AddRelativeTorque(0, vary * 0.5f * temp, 0);

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 2.3f))
            {
                Debug.DrawLine(transform.position, hit.point, Color.red, 2f);
                if (rb != null) rb.AddRelativeTorque(0, vary * 2f, 0);
                


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

            if (Physics.Raycast(transform.position, transform.forward + transform.right, out hit, 2f))
            {
                Debug.DrawLine(transform.position, hit.point, Color.red, 2f);
                if (rb != null) rb.AddRelativeTorque(0, -vary * 1.5f, 0);
            }

            if (Physics.Raycast(transform.position, transform.forward - transform.right, out hit, 2f))
            {
                Debug.DrawLine(transform.position, hit.point, Color.red, 2f);
                if (rb != null) rb.AddRelativeTorque(0, vary * 1.5f, 0);
            }

            /*
            if (Vector3.Angle(transform.position, wavePoint.transform.position) > 0)
            {
                rb.AddRelativeTorque(0,vary,0);
            }
            else
            {
                rb.AddRelativeTorque(0,-vary,0);
            }
                //use torque for ray cast manuvering
            //rb.AddRelativeTorque(speedDirection);
            */
        }

        #region Health

        private void OnHurtEvent()
        {
            currentState.Exit();
        }

        private void OnDeathEvent()
        {
            GetComponent<Health>().OnHurtEvent -= OnHurtEvent;
            GetComponent<Health>().OnDeathEvent -= OnDeathEvent;
            GetComponent<Energy>().OnReducingEvent -= OnReducingEvent;
            currentState.Exit();
            Destroy(gameObject);
        }

        #endregion

        #region States

        public StateBase currentState;
        public float vary;

        public void ChangeState(StateBase newState)
        {
            /*
             * check current state
             * exit current state
             * enter new state
             * update current state
             */
            newState.Enter();
            Debug.Log("Change state here");
            currentState = newState;
        }

        private void OverrideState()
        {
            enemySeen = Target != null;
            if (currentState != null) currentState.Exit();
        }

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.gameObject.GetComponent<CharacterBase>())
            {
                if (other.transform.gameObject.GetComponent<Vestra_Model>()) return;
                if (other.transform.gameObject.GetComponent<Darkling_Model>()) return;
                Target = other.transform.gameObject;
                if (!fleeing)OverrideState();
                /*
                 * surroundingEnemies.Add(other.transform.gameObject);
                 
                if (surroundingEnemies.Count > 1)
                {
                    Target = _targeting.CheckDistance(surroundingEnemies);
                    return;
                }
                Target = other.transform.gameObject;
                OverrideState();
                */
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (Target == other.gameObject)
            {
                Target = null;
                if (!fleeing)OverrideState();
            }
            
            //surroundingEnemies.Remove(other.transform.gameObject);
            // if (Target == other.transform.gameObject) Target = _targeting.CheckDistance(surroundingEnemies);
        }
    }
    
}