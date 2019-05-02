using System;
using System.Collections;
using System.Collections.Generic;
using ReGoap.Core;
using ReGoap.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildHouseAction : ReGoapAction<string,object>
{
    public GameObject house;
    public Transform houseLocation;
    public Transform housePos;
    protected override void Awake()
    {
        base.Awake();
        preconditions.Set("hasHammer", true);
        preconditions.Set("WoodCollected", true);
        effects.Set("houseBuilt", true);
    }

    public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next, ReGoapState<string, object> settings, ReGoapState<string, object> goalState, Action<IReGoapAction<string, object>> done,
        Action<IReGoapAction<string, object>> fail)
    {
        base.Run(previous, next, settings, goalState, done, fail);
        Debug.Log("House Built");
        transform.position = housePos.position;
        StartCoroutine(WaitASec());
        Instantiate(house, houseLocation);

    }
    
    public override void Exit(IReGoapAction<string, object> next)
    {
        base.Exit(next);
        var worldState = agent.GetMemory().GetWorldState();
        foreach (var pair in effects.GetValues())
        {
            worldState.Set(pair.Key,pair.Value);
        }

        StartCoroutine(Finished());
    }
    
    IEnumerator WaitASec()
    {
        yield return new WaitForSeconds(1);
        doneCallback(this);
    }

    IEnumerator Finished()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
