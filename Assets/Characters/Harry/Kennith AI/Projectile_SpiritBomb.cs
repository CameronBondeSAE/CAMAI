using System.Collections.Generic;
using UnityEngine;

namespace Kennith
{
    
    public class Projectile_SpiritBomb : MonoBehaviour
    {
        [SerializeField]
        protected Vector3 scaleIncrease = new Vector3(0.02f,0.02f,0.02f);
        [SerializeField]
        protected Vector3 posIncrease = new Vector3(0,0.013f,0);

        private Vector3 desiredScale;
        private Vector3 desiredPos;
        private float desiredRadius;
        
        public float damage = 30;
        
        public Transform target;

        public float travelSpeed = 1;
    
        private Rigidbody body;
        private SphereCollider col;
        public GameObject parent;
        private GameObject visual;

        public bool thrown = false;
        private bool exploding = false;
        private int explosionCount = 0;
        public int explosionInstances = 12;

        private List<GameObject> _damagedObjects = new List<GameObject>();
        
        private void Awake()
        {
            body = GetComponent<Rigidbody>();
            col = GetComponent<SphereCollider>();
            visual = GetComponentInChildren<Renderer>().gameObject;

            desiredPos = Vector3.zero;
            desiredScale = visual.transform.localScale;
            
        }

        private void Start()
        {
            parent.GetComponent<Health>().OnDeathEvent += Explode;
        }

        void Update()
        {
            if (exploding)
            {
                Explode();
            }
            else
            {
                if (thrown)
                {
                    body.velocity = Vector3.Normalize(target.position - transform.position) * travelSpeed * Time.deltaTime;
                    travelSpeed *= 1.02f;
                }
            }

            Damage();
            
        }

        // I'm aware this is terrible, but I can't work out another way around this right now
        // When a trigger's radius increases it does not receive OnTriggerEnter calls so I can't get this attack to
        // Deal damage to more than a single target 
        // apologies
        private void Damage()
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, col.radius);

            foreach (Collider c in cols)
            {
                if (c.gameObject.GetComponent<Health>() == null) continue;

                if (_damagedObjects.Contains(c.gameObject)) continue;
                
                c.gameObject.GetComponent<Health>().Change(-damage, parent);
                _damagedObjects.Add(c.gameObject);
            }
        }

        public void Power(float power)
        {
            GetComponent<Health>().maxAmount += power;
            GetComponent<Health>().Amount += power;

            damage += 0.6f;

            desiredPos += posIncrease;
            desiredScale += scaleIncrease;
            desiredRadius += scaleIncrease.x / 2;

            
            visual.transform.localScale = Vector3.Lerp(visual.transform.localScale, desiredScale, 0.02f);
            col.radius = desiredRadius;
            if (!thrown) transform.position = Vector3.Lerp(transform.position, desiredPos + transform.position, 0.02f);;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.isTrigger) return;
            if (other.gameObject.GetComponent<ProjectileSyphon>() != null) return;
            if (other.gameObject.GetComponent<ProjectileChase>() != null) return;
            if (other.gameObject.GetComponent<Damager>() != null) return;
            
            exploding = true;
        }

        private void OnDestroy()
        {
            parent.GetComponent<Health>().OnDeathEvent -= Explode;
        }

        public void Explode()
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
                transform.localScale *= 1.02f;
                col.radius *= 1.02f;
            }
        
        }
    }

}

