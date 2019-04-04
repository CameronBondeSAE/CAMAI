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
		effects.Set("hasEnergy", false);
	}

	public override void Run(IReGoapAction<string, object>         previous, IReGoapAction<string, object> next,
							 ReGoapState<string, object>           settings, ReGoapState<string, object>   goalState,
							 Action<IReGoapAction<string, object>> done,
							 Action<IReGoapAction<string, object>> fail)
	{
		base.Run(previous, next, settings, goalState, done, fail);

		// My action code
		transform.Rotate(0, 100f * Time.deltaTime, 0);
		transform.localScale = new Vector3(4,4,4);
		
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