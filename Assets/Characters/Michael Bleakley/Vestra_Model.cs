using System.Linq;
using Michael;
using UnityEngine;
using UnityEngineInternal.Input;

namespace Michael
{
    public class Vestra_Model : CharacterBase
    {
        public  GameObject[] _threats;

        public override void Start()
        {
            GetComponent<Health>().OnHurtEvent += OnHurtEvent;
            GetComponent<Health>().OnDeathEvent += OnDeathEvent;
            GetComponent<Energy>().OnReducingEvent += OnReducingEvent;
        }

        private void Update()
        {
            if (currentState != null) currentState.Execute();

            if (Input.GetKeyDown(KeyCode.A)) ChangeState(fleeState);
            if (Input.GetKeyDown(KeyCode.S)) ChangeState(attackState);
            if (Input.GetKeyDown(KeyCode.D)) ChangeState(roamState);

            OverrideState();
        }

        #region Health

        private void OnHurtEvent()
        {
            if (GetComponent<Health>().Amount < 30) ChangeState(fleeState);
        }

        private void OnDeathEvent()
        {
            Destroy(gameObject);
        }

        #endregion

        #region Energy

        private void OnReducingEvent()
        {
            if (GetComponent<Energy>().Amount < 20) ChangeState(fleeState);
        }

        #endregion
        #region States

        public StateBase roamState;
        public StateBase attackState;
        public StateBase fleeState;

        public StateBase currentState;

        private void ChangeState(StateBase newState)
        {
            /*
             * check current state
             * exit current state
             * enter new state
             * update current state
             */
            if (currentState == newState) return;
            if (currentState != null) currentState.Exit();

            newState.Enter();

            currentState = newState;
        }

        private void OverrideState()
        {
            /*
             * if threat found change to attack
             * if all threats gone change to roam
             * if health low flee/ activate ability
             */
            if (currentState != attackState)
            {
                foreach (var t in _threats)
                {
                    if (t != null)
                    {
                        ChangeState(attackState);
                    }
                }
            }
        }

        #endregion

        public override void Move(Vector3 speedDirection)
        {
            print("moving");
        }

        private void OnTriggerEnter(Collider other)
        {
            _threats.Append(other.gameObject);
        }
    }
}
