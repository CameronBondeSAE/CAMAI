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
			// Use convenience functions to set Dictionary variables
			GetMemory().GetWorldState().Set("hasEnergy", true);
			
			// Manually replan
			CalculateNewGoal(true);
		}
	}
}
