using System;
using System.Collections;
using System.Collections.Generic;
using ReGoap.Core;
using ReGoap.Unity;
using UnityEngine;

public class ChopTreeAction : ReGoapAction<string,object>
{

    public Transform treePos;
    protected override void Awake()
    {
        base.Awake();
        preconditions.Set("treeFound", true);
        preconditions.Set("hasAxe", true);
        effects.Set("hasWood", true);
        
    }

    public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next, ReGoapState<string, object> settings, ReGoapState<string, object> goalState, Action<IReGoapAction<string, object>> done,
        Action<IReGoapAction<string, object>> fail)
    {
        base.Run(previous, next, settings, goalState, done, fail);
        Debug.Log("ChoppingWood");
        transform.position = treePos.position;
        doneCallback(this);
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
