﻿using System;
using System.Collections;
using System.Collections.Generic;
using ReGoap.Core;
using ReGoap.Unity;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Russell
{
    
    public class FindEnemyAction : ReGoapAction<string,object>
    {
        
        Spinner_Model model;
        private WhosAround checkEnemys;
        protected override void Awake()
        {
            
            
            base.Awake();
            model = GetComponent<Spinner_Model>();
            checkEnemys = GetComponent<WhosAround>();
            preconditions.Set("alive", true);
            effects.Set("foundEnemy", true);
        }

        public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next, ReGoapState<string, object> settings, ReGoapState<string, object> goalState, Action<IReGoapAction<string, object>> done,
            Action<IReGoapAction<string, object>> fail)
        {
            base.Run(previous, next, settings, goalState, done, fail);
            if (checkEnemys.whosAround != null)
            {
                model.Target = checkEnemys.whosAround[Random.Range(0, checkEnemys.whosAround.Count)];
                doneCallback(this);
            }
        }
        
        public override void Exit(IReGoapAction<string, object> next)
        {
            base.Exit(next);
            var worldState = agent.GetMemory().GetWorldState();
            foreach (var pair in effects.GetValues())
            {
                worldState.Set(pair.Key,pair.Value);
            }
        }
    }


}
