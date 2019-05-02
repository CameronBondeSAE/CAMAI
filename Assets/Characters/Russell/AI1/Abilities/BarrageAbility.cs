using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Russell
{
    public class BarrageAbility : AbilityBase
    {
        public CapsuleCollider coll;
        public Energy energy;
        public float damageOverTime;
        public GameObject parent;
        public GameObject states;
        public Kyllarr_Model cb;

        private void Awake()
        {            
            states.GetComponent<HoverState>().TargetAquired += Enter;
            energy = parent.GetComponent<Energy>();
            cb = parent.GetComponent<Kyllarr_Model>();
        }


        public override void Enter()
        {
            base.Enter();
            coll.enabled = true;
            energy.Amount = 0f;
            
        }

        public override void Execute()
        {
            base.Execute();
            cb.debugText = "Barrage Attack";

        }

        private void OnTriggerStay(Collider other)
        {
            if (other.GetComponent<CharacterBase>())
            {
                Health health = other.GetComponent<Health>();
                
                if (health != null)
                {
                    health.Change(-damageOverTime * Time.deltaTime, parent );
                }
            
                
            }
            
        }


        
         
    }

}

