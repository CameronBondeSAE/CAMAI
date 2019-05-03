using System.Collections;
using Kennith;
using UnityEngine;

public class ProjectileSyphon : MonoBehaviour
{
    public Transform target;
    
    public float turnSpeed = 1;
    public float travelSpeed = 1;
    public float power = 2;
    
    private Rigidbody body;
    private Collider col;
    
    private bool exploding = false;
    private int explosionCount = 0;
    public int explosionInstances = 12;

    [HideInInspector] public GameObject parentObject;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        StartCoroutine(DeathTimer());
    }

    // Update is called once per frame
    void Update()
    {
        if (exploding)
        {
            Explode();
        }
        else
        {
            if (target == null)
            {
                if (parentObject == null) 
                    Destroy(this.gameObject);
                else 
                    target = parentObject.transform;
            }
            else
            {
                RotateTowards(target.position);
                body.velocity = transform.forward * travelSpeed;
            }
        }   
        
    }

    public void RotateTowards(Vector3 t)
    {
        Vector3 targetDir = t - transform.position;

        // The step size is equal to speed times frame time.
        float step = turnSpeed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);

        // Move our position a step closer to the target.
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != parentObject && other.gameObject.GetComponent<ProjectileChase>() == null)
        {
            if (other.GetComponent<Projectile_SpiritBomb>() != null)
            {
                other.GetComponent<Projectile_SpiritBomb>().Power(power);
            }
            else if (other.GetComponent<Energy>() != null)
            {
                other.GetComponent<Energy>().Change(1);
            }
            
            exploding = true;
        }
    }

    private void Explode()
    {
        col.enabled = false;
        exploding = true;
        body.velocity = Vector3.zero;

        explosionCount++;

        if (explosionCount >= explosionInstances)
        {
            Destroy(this.gameObject);
        }
        else
        {
            transform.localScale *= 0.2f;
        }
        
    }

    private IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(15);

        exploding = true;
    }

}
