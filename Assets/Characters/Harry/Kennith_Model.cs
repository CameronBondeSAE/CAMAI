using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kennith
{
    
    public class Kennith_Model : CharacterBase
    {

        public StateBase_Kennith attackState;
        public StateBase_Kennith wobbleState;
        public StateBase_Kennith currentState;
        
        
        
        public override void Start()
        {
            base.Start();

            GetComponent<Health>().OnHurtEvent += Kennith_Model_OnHurtEvent;
            GetComponent<Health>().OnDeathEvent += Kennith_Model_OnDeathEvent;
        }

        private void Kennith_Model_OnDeathEvent()
        {
            Destroy(gameObject);
        }

        private void Kennith_Model_OnHurtEvent()
        {
            float scaleChange = GetComponent<Health>().lastHealthChangedAmount/100f;
            transform.localScale -= new Vector3(-scaleChange, -scaleChange, -scaleChange);
        }
    }
    
}

