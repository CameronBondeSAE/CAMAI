using System.Collections;
using System.Collections.Generic;
using ReGoap.Core;
using ReGoap.Unity;
using UnityEngine;

public class SoapyGoapAgent : ReGoapAgent<string, object>
{
	private void Update()
	{
		// TODO: Debug cheat
		if (Input.GetKeyDown(KeyCode.Space))
		{
			GetMemory().GetWorldState().Set("hasEnergy", true);
			CalculateNewGoal(true);
		}
	}
}
