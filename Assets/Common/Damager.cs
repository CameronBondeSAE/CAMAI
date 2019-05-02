using UnityEngine;
using System.Collections;

public class Damager : MonoBehaviour
{
	public float scalar = 1;
	public float dangerPingInterval = 1;

	private IEnumerator Start()
	{
		while (true)
		{
			yield return new WaitForSeconds(dangerPingInterval);
			SphereCollider sphereCollider = GetComponent<SphereCollider>();
			if (sphereCollider != null) Danger.OnDangerInvoke(gameObject, null, sphereCollider.radius, 10000f);
		}
	}

	public void OnTriggerStay(Collider other)
	{
		var health = other.gameObject.GetComponent<Health>();

		if (health)
		{
			health.Change(-Time.deltaTime * scalar, gameObject);
		}
	}

}
