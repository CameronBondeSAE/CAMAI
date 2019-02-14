using System.Linq;
using Michael;
using NodeCanvas.BehaviourTrees;
using NodeCanvas.Tasks.Actions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngineInternal.Input;

namespace Michael
{
    public class Vestra_Model : CharacterBase
    {
        public Rigidbody rb;
        
        public override void Start()
        {
            base.Start();            
            GetComponent<Health>().OnHurtEvent += OnHurtEvent;
            GetComponent<Health>().OnDeathEvent += OnDeathEvent;
            GetComponent<Energy>().OnReducingEvent += OnReducingEvent;
        }

        private void Update()
        {
            if (currentState != null) currentState.Execute();
            
            /* test code
            if (Input.GetKeyDown(KeyCode.A)) ChangeState(fleeState);
            if (Input.GetKeyDown(KeyCode.S)) ChangeState(attackState);
            if (Input.GetKeyDown(KeyCode.D)) ChangeState(roamState);
            if (Input.GetKeyDown(KeyCode.Z)) GetComponent<BehaviourTreeOwner>().Tick();
            */
//            OverrideState();
        }

        #region Health

        private void OnHurtEvent()
        {
            GetComponent<BehaviourTreeOwner>().Tick();
        }

        private void OnDeathEvent()
        {
            Destroy(gameObject);
        }

        #endregion
        #region Energy

        private void OnReducingEvent()
        {
            GetComponent<BehaviourTreeOwner>().Tick();
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
        }

        private void OverrideState()
        {
            currentState.Exit();
            /*
             * if threat found change to attack
             * if all threats gone change to roam
             * if health low flee/ activate ability
             */
        }

        #endregion
        # region Abilities

        public override void Ability1()
        {
            Debug.Log("ult");
        }

        public override void Ability2()
        {
            Debug.Log("ability 1");
        }

        public override void Ability3()
        {
            Debug.Log("ability 2");
        }

        #endregion

        public override void Move(Vector3 speedDirection)
        {
             /*
             * add force forward
             * add turning to direction wanted
             * detect collision on sides with ray cast and front to determine turning to avoid obsticles and slowing down speed
             */
            rb.AddRelativeForce(Vector3.forward * SpeedMultiplier, ForceMode.Force);

            var targetPosition = transform.InverseTransformPoint(speedDirection);
            rb.AddRelativeTorque(0,vary * (targetPosition.x/ targetPosition.magnitude),0);

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 7f))
            {
                if (!hitcheck(hit))
                {
                    rb.AddRelativeTorque(0, vary * 10, 0);
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
            }

            if (Physics.Raycast(transform.position, transform.forward + transform.right, out hit, 5f))
            {
                Debug.DrawLine(transform.position, hit.point, Color.red, 2f);
                if (!hitcheck(hit)) rb.AddRelativeTorque(0, -vary * 10, 0);
            }

            if (Physics.Raycast(transform.position, transform.forward - transform.right, out hit, 5f))
            {
                Debug.DrawLine(transform.position, hit.point, Color.red, 2f);
                if (!hitcheck(hit)) rb.AddRelativeTorque(0, vary * 10, 0);
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

        private bool hitcheck(RaycastHit hit)
        {
            if (hit.transform.gameObject.GetComponent<CharacterBase>() == null) return false;
            Target = hit.transform.gameObject;
            //OverrideState();
            return true;
        }
    }
}
