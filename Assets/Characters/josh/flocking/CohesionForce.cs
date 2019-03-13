using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CohesionForce : MonoBehaviour
{
    public float radius = 1;
    public float effect = 1;
    public Vector3 force;

    // Update is called once per frame
    void Update()
    {
        Collider[] temp = Physics.OverlapSphere(gameObject.transform.position, radius);
        Vector3 average = Vector3.zero;
        foreach (Collider item in temp)
        {
            if (item != gameObject.GetComponent<Collider>())
            {
                if (item.gameObject.GetComponent<Boid>())
                {
                    average += item.transform.position;
                }
            }
        }

        average /= temp.Length;
        average -= transform.position;
        force = effect * average.normalized * average.magnitude;
    }
}
