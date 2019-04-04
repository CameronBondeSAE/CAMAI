using System;
using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using ReGoap.Core;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Harry 
{
    
    public class GoapGoatEat : ReGoapAction<string, object>
    {
    
        protected override void Awake()
        {
            base.Awake();
            preconditions.Set("FoodNearby", true);
            effects.Set("isFed", true);
        }
        
        public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next, ReGoapState<string, object> settings, ReGoapState<string, object> goalState, Action<IReGoapAction<string, object>> done, Action<IReGoapAction<string, object>> fail)
        {
            base.Run(previous, next, settings, goalState, done, fail);
            // do your own game logic here
            GetComponent<Renderer>().material.color = new Color(Random.Range(0.5f,1f), Random.Range(0.5f,1f), Random.Range(0.5f,1f), 1);
            // when done, in this function or outside this function, call the done or fail callback, automatically saved to doneCallback and failCallback by ReGoapAction
            doneCallback(this); // this will tell the ReGoapAgent that the action is successfully done and go ahead in the action plan
            // if the action has failed then run failCallback(this), the ReGoapAgent will automatically invalidate the whole plan and ask the ReGoapPlannerManager to create a new plan
            
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


