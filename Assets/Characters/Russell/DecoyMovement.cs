using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Russell
{
    public class DecoyMovement : StateBase
    {
        public Rigidbody rb;
        public float moveSpeed = 5;
        public GameObject decoy;
    
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }
    
        // Start is called before the first frame update

        public override void Execute()
        {
            base.Execute();
            rb.velocity = transform.forward * moveSpeed;
                //AddForce(0,0,moveSpeed *Time.deltaTime);
            StartCoroutine(TimeTillDeath());
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        IEnumerator TimeTillDeath()
        {
            yield return new WaitForSeconds(3);
            Destroy(decoy);
        }
    }


}
