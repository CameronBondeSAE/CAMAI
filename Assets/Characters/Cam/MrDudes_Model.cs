using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrDudes_Model : CharacterBase
{
	public override void Start()
	{
		base.Start();

		GetComponent<Health>().OnHurtEvent += MrDudes_Model_OnHurtEvent;
	}

	private void MrDudes_Model_OnHurtEvent()
	{
		transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
	}
}
