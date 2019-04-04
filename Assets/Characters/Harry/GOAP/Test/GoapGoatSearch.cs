using System;
using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using ReGoap.Core;
using UnityEngine;

namespace Harry
{
   
   public class GoapGoatSearch : ReGoapAction<string, object>
   {
   
      protected override void Awake()
      {
         base.Awake();
         effects.Set("FoodNearby", true);
      }
        
      public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next, ReGoapState<string, object> settings, ReGoapState<string, object> goalState, Action<IReGoapAction<string, object>> done, Action<IReGoapAction<string, object>> fail)
      {
         base.Run(previous, next, settings, goalState, done, fail);
         // do your own game logic here
         transform.localScale *= 1.2f;
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


