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
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(this.transform.position, current.target.transform.position, step);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject == current.target)
            {
                //enter attack mode
                Debug.Log("got here");
            }
            else
            {
                //realize you done fucked up
            }
        }
    }
}