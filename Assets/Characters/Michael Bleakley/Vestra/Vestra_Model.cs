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

        public SpawnState spawnState;
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
            
            falling = transform.position.y < 0.1f;
            if (falling) currentState.Exit();
            
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
            

            var targetPosition = transform.InverseTransformPoint(speedDirection);
            var temp = targetPosition.x / targetPosition.magnitude;
            if (rb != null) rb.AddRelativeTorque(0, (vary * 0.5f * temp) < 0.001f ? 0.001f : (vary * 0.5f * temp), 0);

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 2.3f))
            {
                if (rb != null) rb.AddRelativeTorque(0, vary * 2f, 0);
                rb.AddRelativeForce(-Vector3.forward * (SpeedMultiplier * 0.5f), ForceMode.Force);
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
            else
            {
                if (rb != null) rb.AddRelativeForce(Vector3.forward * SpeedMultiplier, ForceMode.Force);
            }

            if (Physics.Raycast(transform.position, transform.forward + transform.right, out hit, 2f))
            {
                if (rb != null) rb.AddRelativeTorque(0, -vary * 1.5f, 0);
                rb.AddRelativeForce(-Vector3.forward * (SpeedMultiplier * 0.5f), ForceMode.Force);
            }

            if (Physics.Raycast(transform.position, transform.forward - transform.right, out hit, 2f))
            {
                if (rb != null) rb.AddRelativeTorque(0, vary * 1.5f, 0);
                rb.AddRelativeForce(-Vector3.forward * (SpeedMultiplier * 0.5f), ForceMode.Force);
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
            if (currentState != spawnState) return;
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
            currentState = newState;
            debugText = currentState.name;
        }

        private void OverrideState()
        {
            enemySeen = Target != null;
            if (currentState != null) currentState.Exit();
        }

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.isTrigger) return;
            if (other.transform.gameObject.GetComponentInChildren<CharacterBase>())
            {
//                Debug.Log("Testing entry on attack");
                if (other.transform.gameObject.GetComponent<Vestra_Model>()) return;
                if (other.transform.gameObject.GetComponent<Darkling_Model>()) return;
                Target = other.transform.gameObject;
                SpawnState temp1 = GetComponentInChildren<SpawnState>();
                foreach (var i in temp1.darklings)
                {
                    if (i == null) continue;
                    Darkling_Model temp2 = i.GetComponent<Darkling_Model>();
                    temp2.Target = Target;
                    temp2.OverrideState();
                }
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
    }
    
}