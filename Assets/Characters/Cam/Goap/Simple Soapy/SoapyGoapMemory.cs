using System.Collections;
using System.Collections.Generic;
using ReGoap.Core;
using ReGoap.Unity;
using UnityEngine;

public class SoapyGoapMemory : ReGoapMemory<string, object>
{
	protected override void Awake()
	{
		base.Awake();
		GetWorldState().Set("isHappy", false); // Note: You could have normal variables from Unity inspector and copy them in too
		GetWorldState().Set("hasEnergy", false); 
	}
}
