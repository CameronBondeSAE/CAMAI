using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrDudes_Model : CharacterBase
{
	public override void Start()
	{
		base.Start();

		GetComponent<Health>().OnHurtEvent += MrDudes_Model_OnHurtEvent;
		GetComponent<Health>().OnDeathEvent += MrDudes_Model_OnDeathEvent;
	}

	private void MrDudes_Model_OnDeathEvent()
	{
		Destroy(gameObject);
	}

	private void MrDudes_Model_OnHurtEvent()
	{
		float scaleChange = GetComponent<Health>().lastHealthChangedAmount/100f;
		transform.localScale -= new Vector3(-scaleChange, -scaleChange, -scaleChange);
	}
}
