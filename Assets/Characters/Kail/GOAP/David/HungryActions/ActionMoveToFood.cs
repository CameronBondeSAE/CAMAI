﻿using System;
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
            preconditions.Set("childHungry", true);
            preconditions.Set("foundFood", true);
            preconditions.Set("move", true);
            preconditions.Set("hasFood", false);
            
            effects.Set("nearChild", false);
            effects.Set("move", false);
            effects.Set("pickUp", true);

            pickedFood = GetComponent<ActionFindFood>().pickedFood;

        }

        public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next,
            ReGoapState<string, object> settings, ReGoapState<string, object> goalState,
            Action<IReGoapAction<string, object>> done, Action<IReGoapAction<string, object>> fail)
        {
            base.Run(previous, next, settings, goalState, done, fail);
            
            //look at food
            transform.LookAt(pickedFood.transform);
            
        }
        
        private void FixedUpdate()
        {
            //move
            RaycastHit hit;
            if (Physics.Linecast(this.transform.position, pickedFood.transform.position, out hit))
            {
                if (hit.distance <= 1)
                {
                    //pick up item
                    doneCallback(this);
                }
                else
                {
                    //movement
                    float step = 1 * Time.deltaTime;
                    transform.position = UnityEngine.Vector3.MoveTowards(transform.position, pickedFood.transform.position, step);
                }
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