using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectorend : MonoBehaviour
{
    public Vector3 start;

    public float radius = 1;
    public float seed = 0;
    public bool rotation = false;
    
    // Start is called before the first frame update
    void Awake()
    {
        seed = Random.value*radius;
        start = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!rotation)
        {
            transform.position = start + (new Vector3(Mathf.PerlinNoise(Time.time/4,seed)-0.5f, Mathf.PerlinNoise(Time.time/2,seed)-0.5f, Mathf.PerlinNoise(Time.time,seed)-0.5f)*radius);
        }
        else
        {
            transform.rotation = Quaternion.Euler(radius*(Mathf.PerlinNoise(Time.time,seed)-0.5f),0,0);
        }
    }
}
