using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kail
{
    public class SY_AttackState : StateBase
    {
        //starts once its hit the target the first time
        private SuckerYouController current;
        public int timer;
        
        private void Awake()
        {
            current = GetComponentInParent<SuckerYouController>();
        }

        public override void Enter()
        {
            base.Enter();
            timer = 40;
        }

        private void FixedUpdate()
        {
            if (current.hitOther)
            {
                //make sure to be constantly bumping into the target
                float step = 7 * Time.deltaTime;
                transform.parent.position =
                    Vector3.MoveTowards(this.transform.position, current.target.transform.position, step);
                
                if (timer <= 0)
                {
                    //take one hit of health
                    current.target.GetComponent<Health>().Amount -= 1;
                    timer = 40;
                }
                else timer--;
            }
        }

        public override void Exit(int nextState)
        {
            base.Exit(nextState);
            current.hitOther = false;
        }
    }
}