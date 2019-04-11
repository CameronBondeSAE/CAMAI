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

    public class ActionMoveToFood : ReGoapAction<string, object>
    {
    
        public GameObject pickedFood;
    
        protected override void Awake()
        {
            base.Awake();
            Name = "actionMoveToFood";
            preconditions.Set("childHungry", false);
            preconditions.Set("foundFood", true);
            
            effects.Set("nearChild", false);
            effects.Set("Move", true);

            pickedFood = GetComponent<ActionFindFood>().pickedFood;
            //YOU ARE HERE, MAKE DAVID MOVE TO FOOD

        }

        public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next,
            ReGoapState<string, object> settings, ReGoapState<string, object> goalState,
            Action<IReGoapAction<string, object>> done, Action<IReGoapAction<string, object>> fail)
        {
            base.Run(previous, next, settings, goalState, done, fail);
            
            //look at child
            transform.LookAt(pickedFood.transform);
            
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