﻿using System;
using System.Collections;
using System.Collections.Generic;
using NodeCanvas.DialogueTrees;
using ReGoap.Core;
using ReGoap.Unity;
using UnityEngine;

namespace Michael
{
    public class GoatSleep : ReGoapAction<string,object>
    {
        protected override void Awake()
        {
            base.Awake();
            preconditions.Set("hungry", false);
            preconditions.Set("hasEnergy", false);
            effects.Set("hasEnergy", true);
        }

        public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next, ReGoapState<string, object> settings, ReGoapState<string, object> goalState, Action<IReGoapAction<string, object>> done,
            Action<IReGoapAction<string, object>> fail)
        {
            base.Run(previous, next, settings, goalState, done, fail);
            print("sleep");
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
