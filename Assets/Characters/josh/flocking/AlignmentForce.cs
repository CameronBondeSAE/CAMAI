using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignmentForce : MonoBehaviour
{
    public float radius = 1;

    public Quaternion force;

    // Update is called once per frame
    void Update()
    {
        Collider[] temp = Physics.OverlapSphere(gameObject.transform.position, radius);
        Vector3 average = Vector3.zero;
        Vector3 average2 = Vector3.zero;
        float amount = 0;
        foreach (Collider item in temp)
        {
            if (item != gameObject.GetComponent<Collider>())
            {
                if (item.gameObject.GetComponent<Boid>())
                {
                    average += item.transform.forward;
                    average2 += item.transform.up;
                    amount++;
                }
            }
        }

        average /= amount;
        average2 /= amount;
        //force = average;
        force = Quaternion.LookRotation(average.normalized, average2.normalized);
        transform.rotation = Quaternion.Slerp(transform.rotation,force,Time.deltaTime);
    }
}
