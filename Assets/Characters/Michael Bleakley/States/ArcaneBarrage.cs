using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Michael
{
    public class ArcaneBarrage : StateBase
    {
        private bool fired;
        [SerializeField] private GameObject missle;
        public override void Enter()
        {
            Invoke("Barrage", delay);
        }

        public override void Execute()
        {
            Self.transform.LookAt(Self.GetComponent<Vestra_Model>().Target.transform.position);
            RaycastHit hit;
            if (Physics.Linecast(Self.transform.position, Self.GetComponent<Vestra_Model>().Target.transform.position, out hit))
            {
                if (hit.transform.gameObject != Self.GetComponent<Vestra_Model>().Target) Exit();
            }
        }

        private void Barrage()
        {
            if (fired)
            {
                Instantiate(missle, Self.transform.position + Self.transform.forward + Self.transform.right, Self.transform.rotation);
                Instantiate(missle, Self.transform.position + Self.transform.forward - Self.transform.right, Self.transform.rotation);
                fired = false;
                Exit();
            }
            else
            {
                Instantiate(missle, Self.transform.position + Self.transform.forward, Self.transform.rotation);
                fired = true;
                    Invoke("Barrage", 1);
            }
        }
    }
}
