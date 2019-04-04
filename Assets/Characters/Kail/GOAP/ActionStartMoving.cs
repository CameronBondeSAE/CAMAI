using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using ReGoap.Core;
using ReGoap.Unity;
using ReGoap.Unity.FSMExample.Actions;
using ReGoap.Unity.FSMExample.FSM;
using UnityEngine;

namespace Kail
{

    public class ActionStartMoving : ReGoapAction<string, object>
    {
    
        public GameObject child;
    
        protected override void Awake()
        {
            base.Awake();
            preconditions.Set("childHappy", false);
            effects.Set("nearChild", false);
            effects.Set("Move", true);
            //effects.Set("childHappy", true);
            
            child = GameObject.FindWithTag("child");
            
        }

        public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next,
            ReGoapState<string, object> settings, ReGoapState<string, object> goalState,
            Action<IReGoapAction<string, object>> done, Action<IReGoapAction<string, object>> fail)
        {
            base.Run(previous, next, settings, goalState, done, fail);
            
            //look at child
            transform.LookAt(child.transform);
            
            //success
            doneCallback(this);
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