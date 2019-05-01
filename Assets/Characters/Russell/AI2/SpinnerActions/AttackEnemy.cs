using System;
using System.Collections;
using System.Collections.Generic;
using ReGoap.Core;
using ReGoap.Unity;
using UnityEngine;

namespace Russell
{
    public class AttackEnemy : ReGoapAction<string,object>
    {

        public Spinner_Model model;
        public GameObject newTarget;
        public float damage;
        public Energy energy;
        protected override void Awake()
        {
            base.Awake();
            model = GetComponent<Spinner_Model>();
            preconditions.Set("foundEnemy",true);
            preconditions.Set("fullEnergy", true);
            effects.Set("EnemyDamaged", true);
            
            
        }

        public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next, ReGoapState<string, object> settings, ReGoapState<string, object> goalState, Action<IReGoapAction<string, object>> done,
            Action<IReGoapAction<string, object>> fail)
        {
            base.Run(previous, next, settings, goalState, done, fail);
            newTarget = model.Target;
            transform.position = newTarget.transform.position - newTarget.transform.forward * 2;
            transform.LookAt(newTarget.transform);
            Health targetHealth = newTarget.GetComponent<Health>();
            
            targetHealth = newTarget.GetComponent<Health>();
            targetHealth.Change(-damage,this.gameObject);
            energy.Amount = 0f;
            StartCoroutine(WaitASec());

            if (energy.Amount == 0)
            {
                StartCoroutine(Failed()); 
            }
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
        
        IEnumerator WaitASec()
        {
            yield return new WaitForSeconds(1);
            doneCallback(this);
        }
        IEnumerator Failed()
        {
            yield return new WaitForSeconds(1);
            failCallback(this);
        }
    }


}
