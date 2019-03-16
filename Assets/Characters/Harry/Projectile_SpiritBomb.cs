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
        
        public float damage = 30;
        
        public Transform target;

        public float travelSpeed = 1;
    
        private Rigidbody body;
        private Collider col;
        public GameObject parent;

        public bool thrown = false;
        private bool exploding = false;
        private int explosionCount = 0;
        public int explosionInstances = 12;
        
        // DAMAGE DOESNT WORK WITH SCALE INCREASE GO FIX IT MONKEY
        
        private void Awake()
        {
            body = GetComponent<Rigidbody>();
            col = GetComponent<Collider>();

            desiredPos = Vector3.zero;
            desiredScale = transform.localScale;

            GetComponent<Health>().OnDeathEvent += Explode;
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
        
        }

        public void Power(float power)
        {
            GetComponent<Health>().maxAmount += power;
            GetComponent<Health>().Amount += power;

            damage++;

            desiredPos += posIncrease;
            desiredScale += scaleIncrease;

            transform.localScale = Vector3.Lerp(transform.localScale, desiredScale, 0.02f);
            if (!thrown) transform.position = Vector3.Lerp(transform.position, desiredPos + transform.position, 0.02f);;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<ProjectileSyphon>() == null)
            {
                if (other.GetComponent<Health>() != null)
                {
                    other.GetComponent<Health>().Change(-damage, parent);
                    exploding = true;
                }
                else
                {
                    exploding = true;
                }
            }
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
            }
        
        }
    }

}

