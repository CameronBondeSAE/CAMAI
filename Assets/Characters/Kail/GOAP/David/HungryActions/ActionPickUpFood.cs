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

    public class ActionPickUpFood : ReGoapAction<string, object>
    {
    
        public GameObject pickedFood;
        public DetsFood food;
    
        protected override void Awake()
        {
            base.Awake();
            Name = "actionMoveToFood";
            preconditions.Set("childHungry", true);
            preconditions.Set("foundFood", true);
            preconditions.Set("move", false);
            preconditions.Set("hasFood", false);
            preconditions.Set("pickUp", true);
            
            effects.Set("move", true);
            effects.Set("hasFood", true);

            pickedFood = GetComponent<ActionFindFood>().pickedFood;

        }

        public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next,
            ReGoapState<string, object> settings, ReGoapState<string, object> goalState,
            Action<IReGoapAction<string, object>> done, Action<IReGoapAction<string, object>> fail)
        {
            base.Run(previous, next, settings, goalState, done, fail);
            
            //record what food you have
            food = pickedFood.GetComponent<DetsFood>();
            
            //run code to make food destroy itself
            pickedFood.GetComponent<DetsFood>().PickedUp();
            
            //move to child
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