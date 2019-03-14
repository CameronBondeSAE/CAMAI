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
        public float currentHealth;
        public Transform myNewSpot;
        public Transform decoySpawn;
        public GameObject decoy;
        public bool decoyOnCooldown = true;

        public float decoyCooldown = 10f;
        // Start is called before the first frame update

        private void Awake()
        {
            myHealth = myAi.GetComponent<Health>();
            myAi.GetComponent<Kyllarr_Model>().GotHurt += SpawnMyClone;
            //decoyOnCooldown = false;
        }

        private void Start()
        {
            StartCoroutine(Cooldown());
        }

        private void SpawnMyClone()
        {
            if (decoyOnCooldown == false)
            {
                decoyOnCooldown = true;
                currentHealth = myHealth.Amount;
                
                GameObject clone1 = Instantiate(decoy, decoySpawn.position, Quaternion.Euler(0,45,0));
                GameObject clone2 =  Instantiate(decoy, myNewSpot.position, Quaternion.Euler(0,-45,0));

                clone1.GetComponent<Health>().Amount = currentHealth /2;
                clone2.GetComponent<Health>().Amount = currentHealth / 2;
                //replacementAi = Instantiate(myAi, myNewSpot.position, Quaternion.Euler(0,-45,0) );
                //_newHealth = decoy1.GetComponent<Health>();
               // _newHealth.maxAmount = currentHealth / 2;
                
                
                Destroy(myAi);
                
                StartCoroutine(Cooldown());
            }
            
            
            //
        }


        IEnumerator Cooldown()
        {
            yield return new WaitForSeconds(decoyCooldown);
            decoyOnCooldown = false;
        }
    }


}
