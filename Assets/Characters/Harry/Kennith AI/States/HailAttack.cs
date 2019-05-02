using System.Collections;
using System.Collections.Generic;
using NodeCanvas.Tasks.Actions;
using UnityEngine;

namespace Kennith
{
    public class HailAttack : StateBase
    {

        private Quaternion randRotation;
        private Vector3 randOffset;
        private Kennith_Model model;
        private Energy energy;
        
        public GameObject hailProjectile;

        public float randomizedAngle = 60;
        public float energyCost = 4;
        
        private int delayTick;
        public int delay = 2;

        private void Awake()
        {
            model = GetComponentInParent<Kennith_Model>();
            energy = GetComponentInParent<Energy>();
        }

        public override void Tick()
        {
            model.LookAt(model.TargetObject, 1);
            
            // Debug.Log("Hail Attack Execute", gameObject);
            if (model.TargetObject == null)
            {
                Exit();
                return;
            }
            
            randOffset = new Vector3(Random.Range(-0.5f, 0.5f), 1, Random.Range(-0.5f, 0.5f));

            Vector3 lookPos = (transform.position + randOffset) - model.transform.position;
            lookPos.y = 0;
            randRotation = Quaternion.LookRotation(lookPos);   
            
            if (energy.Amount > 0 && delayTick >= delay)
            {
                GameObject spawn = Instantiate(hailProjectile, transform.position + randOffset, Quaternion.identity);
                
                spawn.transform.rotation = Quaternion.Slerp(spawn.transform.rotation, randRotation, 1); 
                spawn.transform.rotation = Quaternion.Inverse(spawn.transform.rotation);
                spawn.transform.LookAt(spawn.transform.position + spawn.transform.forward + (Vector3.up * 1.5f));
                
                spawn.GetComponent<ProjectileChase>().parentObject = model.gameObject;
                spawn.GetComponent<ProjectileChase>().target = model.TargetObject.transform;
                
                energy.Amount -= energyCost;
                delayTick = 0;
            }
            else
            {
                delayTick++;
            }
            
            if (energy.Amount < 0) 
            {
                Exit();
            }

        }

        public override void Exit()
        {
            // Debug.Log("Hail Attack Exit", gameObject);
            
            base.Exit();
        }
    }

}

