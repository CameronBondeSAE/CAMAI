using System;
using System.Collections;
using System.Collections.Generic;
using ReGoap.Core;
using ReGoap.Unity;
using UnityEngine;

public class FindCoverAction : ReGoapAction<string, object>
{
    public Vector3 coverPosition;
    
    protected override void Awake()
    {
        base.Awake();
        
        preconditions.Set("canSeeTarget", true);
        effects.Set("isHidden", true);
    }

    public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next, ReGoapState<string, object> settings, ReGoapState<string, object> goalState, Action<IReGoapAction<string, object>> done,
        Action<IReGoapAction<string, object>> fail)
    {
        base.Run(previous, next, settings, goalState, done, fail);
        
        Debug.Log("Finding cover");
        
        
        float closestDistance = float.MaxValue;
        GameObject closestGO = null;
        
        // My action code
        
        // Find closest obstacle
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Obstacle"))
        {
            float distance = Vector3.Distance(transform.position, go.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestGO = go;
            }
        }

        // Find cover position. Basically the OTHER side of the nearest obstacle, facing away from the target
        Vector3 directionToTarget = (GetComponent<GaryGoapLOSSensor>().target.position - closestGO.transform.position).normalized;
                                    
        if (closestGO != null)
        {
            coverPosition = closestGO.transform.position - directionToTarget * 4f; // TODO check actual radius
        }

        // TODO HACK, actually move there
        // TELEPORT!
        transform.position = new Vector3(coverPosition.x, transform.position.y, coverPosition.z);
        
        // Success!
        doneCallback(this);
    }

    // Record happy into Memory
    public override void Exit(IReGoapAction<string, object> next)
    {
        base.Exit(next);

        var worldState = agent.GetMemory().GetWorldState();
        // This is for multiple effects. It'll blindly write them all into memory
        foreach (var pair in effects.GetValues())
        {
            worldState.Set(pair.Key, pair.Value);
        }
    }

}
