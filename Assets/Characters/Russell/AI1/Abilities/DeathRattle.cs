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
        private WhosAround cb;
        private Health targetHealth;
        public float deathDamage = 10f;

        private void Awake()
        {
            parent.GetComponent<Kyllarr_Model>().Killme += DamageAllAround;
            cb = parent.GetComponent<WhosAround>();



        }
        void DamageAllAround()
        {
            //foreach (CharacterBase characters in cb.whosAround)
            //{
            //    targetHealth = characters.GetComponent<Health>();
            //    targetHealth.Change(-deathDamage, cb.gameObject);
            //}
            Destroy(parent);
        }

        public override void Exit()
        {
            base.Exit();
            
        }
    }

}


