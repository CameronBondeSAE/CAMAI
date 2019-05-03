using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kail
{
    public class SY_ChaseState : StateBase
    {
        // Speed increases
        // chases after target and attaches self to them once collided
        
        private SuckerYouController current;
        
        public float speed = 7;
        
        private void Awake()
        {
            current = GetComponentInParent<SuckerYouController>();
        }
        
        private void FixedUpdate()
        {
            if (current.currentState == current.chaseState)
            {
                float dist = Vector3.Distance(transform.parent.position, current.target.transform.position);
                
                if (dist <= 1f)
                {
                    //enter attack mode
                    current.hitOther = true;
                }
                float step = speed * Time.deltaTime;
                transform.parent.position =
                    Vector3.MoveTowards(transform.parent.position, current.target.transform.position, step);
            }
            
            
        }
    }
}