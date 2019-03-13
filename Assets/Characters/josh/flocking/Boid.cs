using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public List<Vector3> forces;

    public Quaternion lookat;

    public Vector3 velocity = Vector3.zero;

    public float rotspeed = 0.2f;

    public Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();
        body.velocity = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 average = gameObject.GetComponent<CohesionForce>().force + gameObject.GetComponent<SeperationForce>().force;
        /*
        foreach (Vector3 item in forces)
        {
            average += item;
        }
        */

        average /= 2; //forces.Count;
        
        body.AddForce(average);
        //body.AddTorque(gameObject.GetComponent<AlignmentForce>().force.ToAngleAxis());
        //body.AddTorque();
        //transform.rotation = Quaternion.Slerp(transform.rotation,gameObject.GetComponent<AlignmentForce>().force,rotspeed*Time.deltaTime);
    }
}
