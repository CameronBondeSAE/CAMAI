using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilSphere : MonoBehaviour
{
	public float speed;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		transform.Translate(new Vector3(-1f + (Mathf.PerlinNoise(Time.time, 0) * 2.1f),
										0,
										-1f + (Mathf.PerlinNoise(Time.time * 2.2f, 0) * 2.1f))*speed, Space.Self);
	}
}