using System.Collections;
using System.Collections.Generic;
using NodeCanvas.BehaviourTrees;
using NodeCanvas.Tasks.Actions;
using Russell;
using UnityEditor.MemoryProfiler;
using UnityEngine;

namespace Kennith
{
    public class DeathState : StateBase
    {
        private GameObject parent;
        public GameObject deathParticle;
            
        public override void Enter()
        {
            // Debug.Log("A Kennith has died", gameObject);  
            parent = GetComponentInParent<Kennith_Model>().gameObject;
            
            GetComponentInParent<Kennith_Controller>().enabled = false;
            GetComponentInParent<Health>().enabled = false;
            GetComponentInParent<Energy>().enabled = false;
            GetComponentInParent<BehaviourTreeOwner>().enabled = false;
            GetComponentInParent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }

        public override void Tick()
        {
            Debug.Log(parent.transform.rotation.eulerAngles.x, gameObject);
            if (parent.transform.rotation.eulerAngles.x > 75 || parent.transform.rotation.eulerAngles.x < -75)
            {
                StartCoroutine(DelayExit(endDelay));
            }
            else
            {
                parent.transform.Rotate(3, 0, 0);
            }
        }

        public override void Exit()
        {           
            // INSERT SPAWN PARTICLE EFFECT HERE
            GameObject obj = Instantiate(deathParticle, transform.position, deathParticle.transform.rotation);
            Destroy(obj, deathParticle.GetComponent<ParticleSystem>().startLifetime);
            Destroy(parent.gameObject);
        }
        
    }

}
