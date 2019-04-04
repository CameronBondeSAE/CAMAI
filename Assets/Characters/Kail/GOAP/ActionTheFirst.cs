using System;
using System.Collections;
using System.Collections.Generic;
using ReGoap.Core;
using ReGoap.Unity;
using ReGoap.Unity.FSMExample.Actions;
using UnityEngine;

namespace Kail
{

    public class ActionTheFirst : ReGoapAction<string, object>
    {
        protected override void Awake()
        {
            base.Awake();
            preconditions.Set("childHappy", false);
            effects.Set("nearChild", false);
        }

        public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next,
            ReGoapState<string, object> settings, ReGoapState<string, object> goalState,
            Action<IReGoapAction<string, object>> done, Action<IReGoapAction<string, object>> fail)
        {
            base.Run(previous, next, settings, goalState, done, fail);
            //goto child
            
            //success
            doneCallback(this);
        }

        public override void Exit(IReGoapAction<string, object> next)
        {
            base.Exit(next);

            var worldState = agent.GetMemory().GetWorldState();
            worldState.Set("nearChild", true);
        }
    }
}