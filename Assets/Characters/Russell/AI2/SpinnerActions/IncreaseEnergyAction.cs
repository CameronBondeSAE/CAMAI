using System;
using System.Collections;
using System.Collections.Generic;
using ReGoap.Core;
using ReGoap.Unity;
using Russell;
using UnityEngine;

namespace Russell
{
    public class IncreaseEnergyAction : ReGoapAction<string,object>
    {

        public FindPickup pickup;
        
        protected override void Awake()
        {
            base.Awake();
            pickup = GetComponent<FindPickup>();
            preconditions.Set("foundPickup", true);
            effects.Set("fullEnergy", true);
            
        }

        public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next, ReGoapState<string, object> settings, ReGoapState<string, object> goalState, Action<IReGoapAction<string, object>> done,
            Action<IReGoapAction<string, object>> fail)
        {
            base.Run(previous, next, settings, goalState, done, fail);
            gameObject.transform.position = pickup.newPos.position;
            StartCoroutine(WaitASec());
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
    }


}
