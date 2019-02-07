using Michael;
using UnityEngine;
using UnityEngineInternal.Input;

namespace Michael
{
    public class Vestra_Model : CharacterBase
    {
        private GameObject[] _threats;
        public GameObject target;

        public override void Start()
        {
            GetComponent<Health>().OnHurtEvent += OnHurtEvent;
            GetComponent<Health>().OnDeathEvent += OnDeathEvent;
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

        }

        private void OnDeathEvent()
        {
            Destroy(this.gameObject);
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

        public void OverrideState()
        {
            /*
             * if threat found change to attack
             * if all threats gone change to roam
             * if health low flee/ activate ability
             */
            for (int i = 0; i < _threats.Length; i++)
            {
                if (_threats[i] != null)
                {
                    ChangeState(attackState);
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
        
        }
    }
}
