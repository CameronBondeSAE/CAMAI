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
        public bool enemySeen;
        
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
            enemySeen = Target != null;
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
            currentState.Exit();
            GetComponent<BehaviourTreeOwner>().Tick();
        }

        private void OnDeathEvent()
        {
            currentState.Exit();
            Destroy(gameObject);
        }

        #endregion
        #region Energy

        private void OnReducingEvent()
        {
            currentState.Exit();
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
                   var temp = (targetPosition.x / targetPosition.magnitude);
                   rb.AddRelativeTorque(0,(vary * 0.5f) * temp,0);
       
                   RaycastHit hit;
                   if (Physics.Raycast(transform.position, transform.forward, out hit, 2.3f))
                   {
                   Debug.DrawLine(transform.position, hit.point, Color.red, 2f);
                   rb.AddRelativeTorque(0, vary * 2f, 0);
                       if (hitcheck(hit)) Target = hit.transform.gameObject;
                       
                           
                           
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
                   rb.AddRelativeTorque(0, -vary * 1.5f, 0);
                       if (hitcheck(hit)) Target = hit.transform.gameObject;
                   }
       
                   if (Physics.Raycast(transform.position, transform.forward - transform.right, out hit, 2f))
                   {
                   Debug.DrawLine(transform.position, hit.point, Color.red, 2f);
                   rb.AddRelativeTorque(0, vary *1.5f, 0);
                       if (hitcheck(hit)) Target = hit.transform.gameObject;
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
