using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Russell
{
    public class Decoy : AbilityBase
    {
        public GameObject myAi;
        public GameObject replacementAi;
        private Health myHealth;
        private Health _newHealth;
        public float cooldown;
        public float currentHealth;
        public Transform myNewSpot;
        public Transform decoySpawn;
        public GameObject decoy;
        // Start is called before the first frame update

        private void Awake()
        {
            myHealth = myAi.GetComponent<Health>();
            myAi.GetComponent<Kyllarr_Model>().IGotHurt += SpawnMyClone;
        }

        private void SpawnMyClone()
        {
            currentHealth = myHealth.Amount;
            Instantiate(decoy, decoySpawn.position, Quaternion.Euler(0,45,0));
            replacementAi = Instantiate(myAi, myNewSpot.position, Quaternion.Euler(0,-45,0) );
            _newHealth = myHealth;
            //_newHealth.Amount = currentHealth;
            Destroy(myAi);
            //myAi.GetComponent<Kyllarr_Model>().IGotHurt -= SpawnMyClone;
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
