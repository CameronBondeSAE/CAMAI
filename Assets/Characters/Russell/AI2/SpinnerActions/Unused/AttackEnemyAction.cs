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
            spinner.movementSpeed = 0f;
            Health health = spinner.Target.GetComponent<Health>();

            while (health.Amount != 0)
            {

                health.Change(-damageOverTime * Time.deltaTime, this.gameObject );
                doneCallback(this);
            }
            

            health.OnDeathEvent += SpawnSoul;
            
        }
        
        public override void Exit(IReGoapAction<string, object> next)
        {
            base.Exit(next);
            var worldState = agent.GetMemory().GetWorldState();
            foreach (var pair in effects.GetValues())
            {
                worldState.Set(pair.Key,pair.Value);
            }
        }


        void SpawnSoul()
        {
            //GameObject newSoul = Instantiate()
        }
        
        
        
        
        
    }


}
