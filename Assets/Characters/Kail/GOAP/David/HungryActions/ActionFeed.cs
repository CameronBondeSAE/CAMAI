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

    public class ActionFeed : ReGoapAction<string, object>
    {
        public DetsFood food;
        public GameObject child;

        protected override void Awake()
        {
            base.Awake();
            Name = "actionMoveToFood";
            preconditions.Set("childHungry", true);
            preconditions.Set("foundFood", true);
            preconditions.Set("move", false);
            preconditions.Set("hasFood", true);
            preconditions.Set("nearChild", true);
            
            effects.Set("foundFood", false);
            effects.Set("hasFood", false);
            effects.Set("childHungry", true);

            food = GetComponent<ActionPickUpFood>().food;
            child = GameObject.FindWithTag("child");

        }

        public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next,
            ReGoapState<string, object> settings, ReGoapState<string, object> goalState,
            Action<IReGoapAction<string, object>> done, Action<IReGoapAction<string, object>> fail)
        {
            base.Run(previous, next, settings, goalState, done, fail);

            //run feed script
            child.GetComponent<ChildScript>().Feed(food.hunger);
            child.GetComponent<ChildScript>().HealthSet(food.health);
            
            doneCallback(this);
        }
        
        public override void Exit(IReGoapAction<string, object> next)
        {
            base.Exit(next);
            
            var worldState = agent.GetMemory().GetWorldState();
            
            /*check if child is still hungry
            if (child.GetComponent<ChildScript>().hungry < 10)
            {
                //reset
                worldState.Set("foundFood", false);
                worldState.Set("hasFood", false);
            }
            else
            {
                //child no longer hungry
                worldState.Set("foundFood", false);
                worldState.Set("hasFood", false);
                worldState.Set("childHungry", false);
            }*/

            
            foreach (var pair in effects.GetValues())
            {
                worldState.Set(pair.Key, pair.Value);
            }
        }

    }
}