using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using ReGoap.Core;
using ReGoap.Unity;
using ReGoap.Unity.FSMExample.Actions;
using ReGoap.Unity.FSMExample.FSM;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Kail
{
    public class ActionComfort : ReGoapAction<string, object>
    {
        
        protected override void Awake()
        {
            base.Awake();
            preconditions.Set("childHappy", false);
            preconditions.Set("nearChild", true);
            effects.Set("childHappy", true);
            
        }
        
        public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next,
            ReGoapState<string, object> settings, ReGoapState<string, object> goalState,
            Action<IReGoapAction<string, object>> done, Action<IReGoapAction<string, object>> fail)
        {
            base.Run(previous, next, settings, goalState, done, fail);
            
            Debug.Log("There, there"); 
            doneCallback(this);
        }
            
        public override void Exit(IReGoapAction<string, object> next)
        {
            base.Exit(next);

            var worldState = agent.GetMemory().GetWorldState();
            worldState.Set("childHappy", true);
        }
        
        
    }
}