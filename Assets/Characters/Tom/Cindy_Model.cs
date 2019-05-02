using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Tom
{

    public class Cindy_Model : CharacterBase
    {
        // TODO HACK REMOVE 
        
        public StateBase attackState;
        public StateBase idleState;
        public PanicState panicState;
        [SerializeField]
        private StateBase currentState;
        public Transform myTransform;
        public float teleportRange;
        public float getBigScalar;
        

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
            ChangeState(idleState);

        }
        
        public override void Start()
        {
            base.Start();

            myTransform = GetComponent<Transform>();
        }

        private void Update()
        {
            
            Cindy_Model_OnDeathEvent();
            
            currentState.Execute();
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ChangeState(panicState);
            }
        
            
            
        }

        

        private void Cindy_Model_OnDeathEvent()
        {
              if(GetComponent<Health>().Amount <= 0)
              Destroy(gameObject);
        }

        //private void Cindy_Model_OnHurtEvent()
        //{
        //    float scaleChange = GetComponent<Health>().lastHealthChangedAmount / 100f;
         //   transform.localScale -= new Vector3(-scaleChange, -scaleChange, -scaleChange);
        //}

        

        
    }
}