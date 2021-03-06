﻿using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;

//[RequireComponent(typeof(LineRenderer))]
public class Health : MonoBehaviour
{
    // Variables
    [SerializeField] private float amount = 100;

    public float Amount
    {
        get { return amount; }
        set
        {
            amount = value;
            Change(0); // HACK: Cheap way to check for death and ranges
        }
    }

    public float maxAmount = 100;

    // Event definitions

    public event Action OnDeathEvent;
    public event Action OnHurtEvent;
    public event Action OnHealingEvent;
    public event Action<GameObject> OnDeathEventGameObject;

    public delegate float OnInterceptAttemptedChangeParameters(float amountOfChange);

    public event OnInterceptAttemptedChangeParameters OnInterceptAttemptedChange;

    public event Action<float> OnIncomingChange;
    public event Action<float> OnNewAmount;

    public GameObject lastHealingDealer;
    public GameObject lastDamagingDealer;
    public float lastHealthChangedAmount;

    private GameObject owner;

    LineRenderer lineRenderer;

    // Functions
    public void Awake()
    {
        owner = gameObject;


        // View
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }

        Material material = Resources.Load<Material>("HealthLine");
        lineRenderer.material = material;
    }

    public void Change(float amountOfChange, CharacterBase healthChangeDealer)
    {
        if (healthChangeDealer != null) Change(amountOfChange, healthChangeDealer.gameObject);
    }

    public void Change(float amountOfChange, GameObject healthChangeDealer)
    {
        if (OnIncomingChange != null) OnIncomingChange(amountOfChange);

        // Allow customising amount of change (eg shields/invulnerability etc)
        if (OnInterceptAttemptedChange != null)
        {
            amountOfChange = OnInterceptAttemptedChange(amountOfChange);
        }


        amount = amount + amountOfChange;
        amount = Mathf.Clamp(amount, 0, maxAmount);
        if (OnNewAmount != null) OnNewAmount(amount);

        lastHealthChangedAmount = amountOfChange;

        // Fire off events
        if (amountOfChange > 0)
        {
            if (OnHealingEvent != null) OnHealingEvent();
        }
        else
        {
            if (OnHurtEvent != null) OnHurtEvent();
        }

        if (healthChangeDealer != null)
        {
            if (amountOfChange > 0)
            {
                lastHealingDealer = healthChangeDealer;
                if (owner != null) DrawLine(healthChangeDealer.transform, owner.transform, amountOfChange, Color.green);
            }
            else
            {
                lastDamagingDealer = healthChangeDealer;
                if (owner != null) DrawLine(healthChangeDealer.transform, owner.transform, amountOfChange, Color.red);
            }

            Debug.DrawLine(transform.position, healthChangeDealer.transform.position, Color.red, 0.50f);
        }

        CheckForDeath();
    }

    [Obsolete("Use the Change function that takes a GameObject")]
    public void Change(float amountOfChange)
    {
        if (OnIncomingChange != null) OnIncomingChange(amountOfChange);

        // Allow customising amount of change (eg shields/invulnerability etc)
        if (OnInterceptAttemptedChange != null)
        {
            amountOfChange = OnInterceptAttemptedChange(amountOfChange);
        }

        amount = amount + amountOfChange;
        amount = Mathf.Clamp(amount, 0, maxAmount);

        // Fire off events
        if (amountOfChange > 0)
        {
            if (OnHealingEvent != null) OnHealingEvent();
        }
        else
        {
            if (OnHurtEvent != null) OnHurtEvent();
        }

        CheckForDeath();
    }


    Tweener tweener;

    public void DrawLine(Transform damager, Transform damageReceiver, float amountOfChange, Color colour)
    {
        lineRenderer.startColor = colour/1000f;
        lineRenderer.endColor = colour;
//		lineRenderer.startWidth = (amountOfChange / 10f) / 2f;
        lineRenderer.startWidth = 0.2f;
//		lineRenderer.endWidth = amountOfChange / 10f;
        lineRenderer.endWidth = 0.75f;
        lineRenderer.shadowCastingMode = ShadowCastingMode.Off;

        lineRenderer.SetPosition(0, damager.position);
        lineRenderer.SetPosition(1, damageReceiver.position);

//		DOTween.To(delegate (float value) { lineRenderer.material.color = new Color(colour.r, colour.g, colour.b, value); }, 1f, 0f, amountOfChange / 10f);
        if (tweener != null && tweener.IsActive())
        {
            tweener.Kill();
        }
        tweener = DOTween.To(
            DoSetter, 1f,
            0f, 1f);
        void DoSetter(float value)
        {
            lineRenderer.material.color = new Color(colour.r, colour.g, colour.b, value);
        }
    }

    private void CheckForDeath()
    {
        // Check if it’s smaller than OR EQUAL TO zero.
        if (amount <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (OnDeathEvent != null)
            OnDeathEvent();

        if (OnDeathEventGameObject != null)
            OnDeathEventGameObject(gameObject);
    }
}