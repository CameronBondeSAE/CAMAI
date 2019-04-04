using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReGoap.Core;
using ReGoap.Unity;
using System;

namespace Harry
{
    
    public class ActionGetWood : ReGoapAction<string, object>
    {
        protected override void Awake()
        {
            base.Awake();
            preconditions.Set("TreeAvailable", true);
            effects.Set("HaveWood", true);
        }
        
        public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next, ReGoapState<string, object> settings, ReGoapState<string, object> goalState, Action<IReGoapAction<string, object>> done, Action<IReGoapAction<string, object>> fail)
        {
            base.Run(previous, next, settings, goalState, done, fail);
            // do your own game logic 
            if (GetComponent<BuilderMemory>().remainingWood <= 0)
            {
                effects.Set("TreeAvailable", false);
                failCallback(this);
            }
            else
            {
                GetComponent<BuilderMemory>().remainingWood--;
                doneCallback(this); // this will tell the ReGoapAgent that the action is successfully done and go ahead in the action plan
            }
            
        }

        public override void Exit(IReGoapAction<string, object> next)
        {
            base.Exit(next);

            var worldState = agent.GetMemory().GetWorldState();
            foreach (var pair in effects.GetValues())
            {
                worldState.Set(pair.Key, pair.Value);
            }
        }
    }

}