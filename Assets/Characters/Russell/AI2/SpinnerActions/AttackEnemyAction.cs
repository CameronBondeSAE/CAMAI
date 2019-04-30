using System;
using System.Collections;
using System.Collections.Generic;
using ReGoap.Core;
using ReGoap.Unity;
using UnityEngine;

namespace Russell
{
    public class AttackEnemyAction : ReGoapAction<string, object>
    {
        public float damageOverTime;
        public Spinner_Model spinner;
        public GameObject soul;
        protected override void Awake()
        {
            base.Awake();
            spinner = GetComponent<Spinner_Model>();
            preconditions.Set("hasTarget", true);
            effects.Set("targetKilled", true);
        }

        public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next, ReGoapState<string, object> settings, ReGoapState<string, object> goalState, Action<IReGoapAction<string, object>> done,
            Action<IReGoapAction<string, object>> fail)
        {
            base.Run(previous, next, settings, goalState, done, fail);
            Health health = spinner.Target.GetComponent<Health>();
                
            if (health != null)
            {
                health.Change(-damageOverTime * Time.deltaTime, this.gameObject );
            }

            health.OnDeathEvent += SpawnSoul;

        }


        void SpawnSoul()
        {
            //GameObject newSoul = Instantiate()
        }
        
        
        
        
        
    }


}
