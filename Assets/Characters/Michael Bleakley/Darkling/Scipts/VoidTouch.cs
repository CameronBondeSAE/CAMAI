using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Michael
{
    public class VoidTouch : MonoBehaviour
    {
        private List<GameObject> targets;
        public float damage;
        private CharacterBase self;

        // Start is called before the first frame update
        void Start()
        {
            targets = new List<GameObject>();
            self = GetComponentInParent<Darkling_Model>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (targets.Count >= 1) Damage();
        }

        private void Damage()
        {
            for (int i = 0; i < targets.Count; i++)
            {
                if (targets[i] == null)
                {
                    targets.RemoveAt(i);
                }
                else
                {
                    Health health = targets[i].GetComponentInChildren<Health>();
                    if (health != null) health.Change(-damage, self);
                }
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.gameObject.GetComponentInChildren<Health>())
            {
                if (other.transform.gameObject.GetComponent<Vestra_Model>()) return;
                if (other.transform.gameObject.GetComponent<Darkling_Model>()) return;
                targets.Add(other.gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (targets.Contains(other.gameObject))
            {
                targets.Remove(other.gameObject);
            }
        }
    }
}
