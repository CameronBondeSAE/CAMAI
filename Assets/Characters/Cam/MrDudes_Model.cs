using System;
using Cam;
using Tayx.Graphy.Utils;
using UnityEditorInternal;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Cam
{
	

public class MrDudes_Model : CharacterBase
{

	public StateBase currentState;
	private Transform myTransform;
	public float teleportRange;
	public float getBigScalar;
	public float speed;
	private Rigidbody _rigidbody;
	public float turnSpeedScalar;
	public float upForceScalar;
	public float perlinScalar;

	public AnimationCurve distanceInfluenceCurve;
	public float getBigHitRadius;


	public event Action OnGetBig;

	public void ChangeState(StateBase newState)
	{
		// Check current state isn't the same
		if (newState == currentState) return;

		if (currentState != null) currentState.Exit();
		if (newState != null)
		{
			newState.Enter();

			currentState = newState;
		}
		else
		{
			currentState = null;
		}
	}

	public void EndState()
	{
		// Null the statemachine, so the Behaviour Tree can set the state manually
		ChangeState(null);
	}
	

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
		myTransform = GetComponent<Transform>();
//		ChangeState(wobbleState);

		// Listen/Subscribe to events coming out of Health.
		GetComponent<Health>().OnHurtEvent += Hurt;
		GetComponent<Health>().OnDeathEvent += Death;
	}

	public override void Start()
	{
		base.Start();

		
	}

	private void FixedUpdate()
	{
		// Update statemachine
		if (currentState != null) currentState.Execute();
		
		Move();

		RaycastHit hit;
		if (Physics.Raycast(myTransform.position, myTransform.forward, out hit, 10f))
		{
			_rigidbody.AddRelativeTorque(0,(distanceInfluenceCurve.Evaluate(hit.distance/10f) * turnSpeedScalar),0);			
		}
		
		_rigidbody.AddRelativeTorque(0,(Mathf.PerlinNoise(Time.time,0) * 2f - 1f) * 35f, 0);
		
//		Debug.Log("Dist = "+hit.distance + " : Influence = "+);
	}

	public void Move()
	{
		_rigidbody.AddRelativeForce(0,0,speed*Time.deltaTime, ForceMode.VelocityChange);
	
		// Flying
//		_rigidbody.AddForce(0, Mathf.PerlinNoise(myTransform.position.x * perlinScalar, myTransform.position.z * perlinScalar) * upForceScalar,0);
	}

	private void OnTriggerStay(Collider other)
	{
//		_rigidbody.AddRelativeTorque(0,turnSpeed*Time.deltaTime,0);
	}

	private void Death()
	{
		Destroy(gameObject);
	}

	private void Hurt()
	{
		float scaleChange = GetComponent<Health>().lastHealthChangedAmount/100f;
//		transform.localScale -= new Vector3(-scaleChange, -scaleChange, -scaleChange);
	}

	public void GetBig()
	{
		if (!Application.isPlaying)
		{
			return;
		}
		myTransform.localScale = myTransform.localScale * getBigScalar;
		
		Collider[] colliders = Physics.OverlapSphere(transform.position, getBigHitRadius);
		foreach (Collider c in colliders)
		{
			// Check if they're a "CharacterBase" so I don't affect the floor etc
			CharacterBase characterBase = c.GetComponent<CharacterBase>();

			if (characterBase != null && characterBase != this)
			{
				characterBase.GetComponent<Health>().Change(-1000f, gameObject);
			}
		}

		if (OnGetBig != null) OnGetBig();
	}

}

}
