using System;
using System.Collections;
using System.Collections.Generic;
using NodeCanvas.DialogueTrees;
using ReGoap.Core;
using ReGoap.Unity;
using UnityEngine;

namespace Michael
{
public class GoatWonder : ReGoapAction<string,object>
{
    protected override void Awake()
    {
        base.Awake();
        preconditions.Set("hasEnergy", true);
        effects.Set("hungry", true);
        effects.Set("hasEnergy", false);
        effects.Set("walked", true);
    }

    public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next, ReGoapState<string, object> settings, ReGoapState<string, object> goalState, Action<IReGoapAction<string, object>> done,
        Action<IReGoapAction<string, object>> fail)
    {
        base.Run(previous, next, settings, goalState, done, fail);
        print("wondered");
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
