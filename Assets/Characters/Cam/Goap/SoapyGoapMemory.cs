using System.Collections;
using System.Collections.Generic;
using ReGoap.Core;
using ReGoap.Unity;
using UnityEngine;

public class SoapyGoapMemory : ReGoapMemory<string, object>
{
	public bool isHappy = false;
	public bool hasEnergy = false;

	protected override void Awake()
	{
		base.Awake();
		GetWorldState().Set("isHappy", isHappy); // Normal Unity inspector for initial value
		GetWorldState().Set("hasEnergy", hasEnergy); // Normal Unity inspector for initial value
	}
}
