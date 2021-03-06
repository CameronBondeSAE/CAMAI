﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBar : MonoBehaviour
{
	public Text parentName;
	public Text debugText;
	public Image healthBar;
	public Image energyBar;
	private Health health;
	private Energy energy;
	public float height;
	private float killNum;
	public Text killCount;
	public GameObject killCountImage;
	private Camera mainCamera;

	public CharacterBase owner;

	void Start()
	{
		killCountImage.SetActive(false);
		CharacterBase.OnDestroyed += UpdateKillCount;
		mainCamera = FindObjectOfType<Camera>();
		if (owner == null)
		{
		    this.TryDestroy(gameObject);

            return;
		}

		health = owner.GetComponent<Health>();
		if (health != null)
		{
			health.OnDeathEvent += OnDeathEvent;
			health.OnNewAmount += OnNewHealthAmount;
			CharacterBase.OnDestroyed += CharacterBaseOnDestroyed;

			parentName.text = owner.characterName;
		}

		energy = owner.GetComponent<Energy>();
	}

	private void OnNewHealthAmount(float newAmount)
	{		
		if (health != null) healthBar.fillAmount = newAmount / health.maxAmount;
		
	}

	void UpdateKillCount(CharacterBase characterBase)
	{
		try
		{
			if (characterBase.GetComponent<Health>().lastDamagingDealer == owner)
			{
				killCountImage.SetActive(true);
				killNum++;
				killCount.text = killNum.ToString();
			}
		}
		catch
		{
			//ignore
		}
	}

	private void CharacterBaseOnDestroyed(CharacterBase characterBase)
	{
		if (characterBase == owner)
		{
			owner.GetComponent<Health>().OnDeathEvent -= OnDeathEvent;

			try
			{
				this.TryDestroy(gameObject);
			}
			catch
			{
				//ignore
			}
        }
	}

	private void OnDeathEvent()
	{
	    this.TryDestroy(gameObject);
    }

	void Update()
	{
		debugText.text = owner.debugText;

		if (energy != null) energyBar.fillAmount = energy.Amount / energy.MaxEnergy;

		//Position
		if (owner != null)
		{
			Vector3 screenPos = mainCamera.WorldToScreenPoint(owner.transform.position);
			transform.GetChild(0).position = new Vector3(screenPos.x, screenPos.y + height, screenPos.z);
		}
		else Destroy(gameObject);
	}
}
