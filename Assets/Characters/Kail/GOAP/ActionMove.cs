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
    

    public class ActionMove : ReGoapAction<string, object>
    {
        public GameObject child;
        public UnityEngine.Vector3 offset;

        public float speed;
        
        protected override void Awake()
        {
            base.Awake();
            preconditions.Set("childHappy", false);
            preconditions.Set("nearChild", false);
            preconditions.Set("Move", true);
            effects.Set("nearChild", true);
            effects.Set("Move", false);
            
            child = GameObject.FindWithTag("child");
            
        }
        
        public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next,
            ReGoapState<string, object> settings, ReGoapState<string, object> goalState,
            Action<IReGoapAction<string, object>> done, Action<IReGoapAction<string, object>> fail)
        {
            base.Run(previous, next, settings, goalState, done, fail);
            
            //nothing to really do here
        }

        private void FixedUpdate()
        {
            //move
            RaycastHit hit;
            if (Physics.Linecast(this.transform.position, child.transform.position, out hit))
            {
                if (hit.distance <= 1)
                {
                    //you are close enough to comfort, do so
                    doneCallback(this);
                }
                else
                {
                    //movement
                    float step = speed * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(this.transform.position, child.transform.position, step);
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