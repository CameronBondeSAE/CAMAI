using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{

    public class Cindy_Model : CharacterBase
    {
        // TODO HACK REMOVE 
        public StateBase attackState;
        public StateBase idleState;
        
        public StateBase currentState;
        public Transform myTransform;
        public float teleportRange;
        public float getBigScalar;

        public void ChangeState(StateBase newState)
        {
            //Check current state isn't the same
            if(currentState != null)currentState.Exit();
            newState.Enter();
            currentState = newState;

        }
        
        private void Awake()
        {
            currentState = idleState;    
        }
        
        public override void Start()
        {
            base.Start();

            myTransform = GetComponent<Transform>();
        }

        private void Update()
        {
            
        }     
       


         
        
        private void Cindy_Model_OnDeathEvent()
        {
              
              Destroy(gameObject);
        }

        private void Cindy_Model_OnHurtEvent()
        {
            float scaleChange = GetComponent<Health>().lastHealthChangedAmount / 100f;
            transform.localScale -= new Vector3(-scaleChange, -scaleChange, -scaleChange);
        }
        //TODO move to seperate inheritance 
        public void TeleportRandomly()
        {
            myTransform.position = myTransform.position + new Vector3(Random.Range(-teleportRange, teleportRange), Random.Range(-teleportRange, teleportRange), Random.Range(-teleportRange, teleportRange));
        }

        public void GetBig()
        {
            myTransform.localScale = myTransform.localScale * getBigScalar;
        }
    }
}