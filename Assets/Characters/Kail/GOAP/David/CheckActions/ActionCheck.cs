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
    public class ActionCheck : ReGoapAction<string, object>
    {
        //the child
        public GameObject child;
        private ChildScript childDets;

        //Davids gaols
        private HungryGoal hungry;
        private HappyGoal happy;
        
        protected override void Awake()
        {
            base.Awake();
            Name = "actionCheck";
            
            preconditions.Set("checkChild", false);
            preconditions.Set("nearChild", true);
            effects.Set("checkChild", true);
            
            //find child and its details
            child = GameObject.FindWithTag("child");
            childDets = child.GetComponent<ChildScript>();
            //find goals
            hungry = GetComponentInParent<HungryGoal>();
            happy = GetComponentInParent<HappyGoal>();

            

        }
        
        public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next,
            ReGoapState<string, object> settings, ReGoapState<string, object> goalState,
            Action<IReGoapAction<string, object>> done, Action<IReGoapAction<string, object>> fail)
        {
            base.Run(previous, next, settings, goalState, done, fail);
            
            //check child, set the priority of the next goals based off of its details
            if (childDets.happy < childDets.hungry)
            {
                happy.SetPriority(1);
                hungry.SetPriority(2);
            }
            else
            {
                hungry.SetPriority(1);
                happy.SetPriority(2);
            }

            //on the chance that it starts at ten, set these as what is needed
            if (childDets.happy == 10) effects.Set("childHappy", true);
            if (childDets.hungry == 10) effects.Set("childHungry", false);

            doneCallback(this);
        }
            
        public override void Exit(IReGoapAction<string, object> next)
        {
            base.Exit(next);

            var worldState = agent.GetMemory().GetWorldState();
            worldState.Set("checkChild", true);
        }
        
        
    }
}