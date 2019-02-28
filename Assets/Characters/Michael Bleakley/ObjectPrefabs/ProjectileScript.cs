using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float Damage;
    public GameObject source;
    public GameObject target;
    [SerializeField]
    private int speed;
    [SerializeField] private float turnSpeed;
    private Rigidbody rb;

    [SerializeField] private int delay;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("Destroy", delay);
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward * speed, ForceMode.Force);
        
        if (target == null) return;
        var targetPosition = transform.InverseTransformPoint(target.transform.position);
        var temp = targetPosition.x / targetPosition.magnitude;
        if (rb != null) rb.AddRelativeTorque(0, turnSpeed * 0.5f * temp, 0);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.gameObject == source) return;
        if (other.gameObject.GetComponent<Health>())
        {
            other.gameObject.GetComponent<Health>().Change(-Damage, source);
        }

        Destroy();
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
