﻿using UnityEngine;

namespace Kennith
{
    public class SpiritBomb : StateBase
    {

        public GameObject spiritBomb;
        private GameObject spawnedSpiritBomb;
        
        private Kennith_Model model;
        private Energy energy;
        public int energyCost;
        public Vector3 offset = Vector3.up;
        
        private int delayTick;
        public int delay = 2;
        
        private void Awake()
        {
            model = GetComponentInParent<Kennith_Model>();
            energy = GetComponentInParent<Energy>();
        }
        
        public override void Enter()
        {
            GetComponentInParent<Health>().OnDeathEvent += ExplodeOnDeath;
            
            // Debug.Log("Attack Enter", gameObject);
            spawnedSpiritBomb = Instantiate(spiritBomb, transform.position + offset, transform.rotation);
            spawnedSpiritBomb.GetComponent<Projectile_SpiritBomb>().parent = model.gameObject;
            spawnedSpiritBomb.GetComponent<Projectile_SpiritBomb>().target = model.TargetObject.transform;

            Kennith_Model.ShareYourPower -= model.SyphoningPower;
            model.InvokeShareYourPower(spawnedSpiritBomb);
            
            StartCoroutine(DelayExit(endDelay));
            
        }

        public override void Tick()
        {
           
            // Debug.Log("Attack Execute", gameObject);

            if (energy.Amount > 0 && delayTick >= delay)
            {
                spawnedSpiritBomb.GetComponent<Projectile_SpiritBomb>().Power(energyCost);
                energy.Amount -= energyCost;
                delayTick = 0;
            }
            else
            {
                delayTick++;
            }
        
        }
        
        public override void Exit()
        {
            spawnedSpiritBomb.GetComponent<Projectile_SpiritBomb>().thrown = true;

            GetComponentInParent<Health>().OnDeathEvent -= ExplodeOnDeath;
            Kennith_Model.ShareYourPower += model.SyphoningPower;
            
            // Debug.Log("Attack Exit", gameObject);
            model.ChangeState(model.moveState);
            base.Exit();
        }

        public void ExplodeOnDeath()
        {
            spawnedSpiritBomb.GetComponent<Projectile_SpiritBomb>().Explode();
        }
    }

}