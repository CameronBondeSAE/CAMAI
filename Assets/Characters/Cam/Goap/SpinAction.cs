using System;
using System.Collections;
using System.Collections.Generic;
using ReGoap.Core;
using ReGoap.Unity;
using UnityEngine;

public class SpinAction : ReGoapAction<string, object>
{
    protected override void Awake()
    {
        base.Awake();
        
        preconditions.Set("hasEnergy", true);
        effects.Set("isHappy", true);
    }

    public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next, ReGoapState<string, object> settings, ReGoapState<string, object> goalState, Action<IReGoapAction<string, object>> done,
        Action<IReGoapAction<string, object>> fail)
    {
        base.Run(previous, next, settings, goalState, done, fail);
        
        // My action code
        transform.Rotate(0,100f*Time.deltaTime,0);

        // Record happy into Memory
        agent.GetMemory().GetWorldState().Set("isHappy", true);
        
        // Success!
        doneCallback(this);
    }
}
