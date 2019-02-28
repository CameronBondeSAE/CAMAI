using System.Collections;
using System.Collections.Generic;
using Russell;
using UnityEngine;

namespace Russell
{
    public class DeathRattle : AbilityBase
    {
        // Start is called before the first frame update
        public GameObject parent;
        private Kyllarr_Model cb;
        private Health targetHealth;
        public float deathDamage = 10f;

        private void Awake()
        {
            parent.GetComponent<Kyllarr_Model>().Killme += DamageAllAround;
            cb = parent.GetComponent<Kyllarr_Model>();

            void DamageAllAround()
            {
                foreach (Collider collider in cb.whosAround)
                {
                    targetHealth = collider.GetComponent<Health>();
                    targetHealth.Change(-deathDamage, cb);
                }
            }

            void Start()
            {

            }

            // Update is called once per frame
            void Update()
            {

            }
        }
    }

}


