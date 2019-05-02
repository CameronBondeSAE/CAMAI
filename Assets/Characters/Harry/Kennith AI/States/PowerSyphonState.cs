using System.Transactions;
using UnityEngine;

namespace Kennith
{
    public class PowerSyphonState : StateBase
    {

        private Quaternion randRotation;
        private Vector3 randOffset;
        private Kennith_Model model;
        private Energy energy;
        
        public GameObject syphonProjectile;

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
            if (model.TargetObject == null) Exit();

            randRotation.eulerAngles = new Vector3(Random.Range(-(randomizedAngle * 2), -randomizedAngle), 0, Random.Range(-(randomizedAngle * 2), -randomizedAngle));
            randOffset = new Vector3(Random.Range(-0.5f, 0.5f), 1, Random.Range(-0.5f, 0.5f));

            if (energy.Amount > 0 && delayTick >= delay)
            {
                
                GameObject spawn = Instantiate(syphonProjectile, transform.position + randOffset, randRotation);
                spawn.GetComponent<ProjectileSyphon>().parentObject = model.gameObject;
                spawn.GetComponent<ProjectileSyphon>().target = model.TargetObject.transform;
                
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

