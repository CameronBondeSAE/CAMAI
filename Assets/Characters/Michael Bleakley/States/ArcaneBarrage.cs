using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace Michael
{
    public class ArcaneBarrage : StateBase
    {
        private bool fired;
        [SerializeField] private GameObject missle;
        [SerializeField] int damage;
        [SerializeField] private int range;
        public override void Enter()
        {
            Invoke("Barrage", delay);
        }

        public override void Execute()
        {
            Self.transform.LookAt(Self.GetComponent<Vestra_Model>().Target.transform.position);
            RaycastHit hit;
            if (Vector3.Distance(Self.transform.position, Self.GetComponent<Vestra_Model>().Target.transform.position) > range) Exit();
            if (Physics.Linecast(Self.transform.position, Self.GetComponent<Vestra_Model>().Target.transform.position, out hit))
            {
               if (hit.transform.gameObject != Self.GetComponent<Vestra_Model>().Target) Exit();
            }
        }

        private void Barrage()
        {
            if (fired)
            {
                //Quaternion temp = new Quaternion(0,45,0,0);
                SetMissle(Instantiate(missle, Self.transform.position + Self.transform.forward + Self.transform.right * 2, Self.transform.localRotation));
                SetMissle(Instantiate(missle, Self.transform.position + Self.transform.forward / 2 - Self.transform.right * 2, Self.transform.localRotation));
                
                Invoke("Exit", 2);
            }
            else
            {
                SetMissle(Instantiate(missle, Self.transform.position + Self.transform.forward, Self.transform.localRotation));
                fired = true;
                    Invoke("Barrage", 0.5f);
            }
        }
        
        private void SetMissle(GameObject projectile)
        {
            projectile.GetComponent<ProjectileScript>().target = Self.GetComponent<Vestra_Model>().Target;
            projectile.GetComponent<ProjectileScript>().Damage = damage * Self.GetComponent<Vestra_Model>().DamageMultiplier;
            projectile.GetComponent<ProjectileScript>().source = Self;
        }

        public override void Exit()
        {
            fired = false;
            base.Exit();
        }
    }
}
