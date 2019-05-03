using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEditorInternal;
using UnityEngine;

namespace Tom
{

    public class Barry_Model : CharacterBase
    {


        public StateBase calmState;
        public StateBase idleState;
        public StateBase spinState;

        //public PanicState panicState;
        [SerializeField]
        private StateBase currentState;
        public Transform myTransform;
        //public float teleportRange;
        //public float getBigScalar;
        

        public void ChangeState(StateBase newState)
        {
            // Check current state isn't the same
            if (newState == currentState) return;

            if (currentState != null) currentState.Exit();
            if (newState != null)
            {
                newState.Enter();

                currentState = newState;
            }
            else
            {
                currentState = null;
            }
            
        }
        
        
        
        private void Awake()
        {
            GetComponent<Health>().OnDeathEvent += Barry_Model_OnDeathEvent;
            
            ChangeState(idleState);

        }
        
        public override void Start()
        {
            base.Start();

            myTransform = GetComponent<Transform>();
        }

        private void Update()
        {
            
            
            currentState.Execute();
            //if (GetComponent<Health>().OnHurtEvent = )
            //{
            //    ChangeState(panicState);
            //}
            
            
        }

        //MAKE A FUNCTION THAT USES CHANGE STATE TO PANIC STATE AS SHOWN ABOVE IN UPDATE

        private void Barry_Model_OnDeathEvent()
        {
              Destroy(gameObject);
        }

        //private void Cindy_Model_OnHurtEvent()
        //{
        //    float scaleChange = GetComponent<Health>().lastHealthChangedAmount / 100f;
         //   transform.localScale -= new Vector3(-scaleChange, -scaleChange, -scaleChange);
        //}

        

        
    }
}