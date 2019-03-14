using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Michael
{
    public class ArcaneBarrage : StateBase
    {
        private int count;
        [SerializeField] private int cost;
        [SerializeField] private GameObject missle;
        [SerializeField] private int damage;
        [SerializeField] private int range;
        [SerializeField] private int noProj;
        public override void Enter()
        {
            count = 0;
            Invoke("Barrage", delay);
        }

        public override void Execute()
        {
            base.Execute();
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
            if (count >= noProj)
            {
                Self.GetComponent<Energy>().Change(-cost);
                Self.transform.rotation = new Quaternion(0,Self.transform.rotation.y,0,Self.transform.rotation.w);
            }
            else
            {
                SetMissle(Instantiate(missle, Self.transform.position + Self.transform.forward * 1.5f , Self.transform.localRotation));
                count++;
                Invoke("Barrage", 0.5f);
            }
        }
        
        private void SetMissle(GameObject projectile)
        {
            projectile.GetComponent<ProjectileScript>().target = Self.GetComponent<Vestra_Model>().Target;
            projectile.GetComponent<ProjectileScript>().Damage = damage * Self.GetComponent<Vestra_Model>().DamageMultiplier;
            projectile.GetComponent<ProjectileScript>().source = Self;
        }
    }
}
