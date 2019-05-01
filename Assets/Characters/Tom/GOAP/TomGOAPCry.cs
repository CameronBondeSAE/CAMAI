using System;
using System.Collections;
using System.Collections.Generic;
using ReGoap.Core;
using ReGoap.Unity;
using UnityEngine;

public class TomGOAPCry : ReGoapAction<string, object>
{
    /*//REMOVED AND TAKEN OVER TO TomGOAPcryAction1
    protected override void Awake()
    {
        base.Awake();
        preconditions.Set("hasChuggedWater", true);
        effects.Set("canCry", true);
    }*/

    public override void Run(IReGoapAction<string, object>         previous, IReGoapAction<string, object> next,
        ReGoapState<string, object> settings, ReGoapState<string, object>   goalState,
        Action<IReGoapAction<string, object>> done,
        Action<IReGoapAction<string, object>> fail)
    {
        base.Run(previous, next, settings, goalState, done, fail);

        // My action code
        GetComponent<Renderer>().material.color = Color.blue;
        Debug.Log("IM BLUE NOW");
        
        // Success!
        doneCallback(this);
    }

    // Record happy into Memory
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
    