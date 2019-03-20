using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cam
{
    public class Neighbours : MonoBehaviour
    {
        public List<Rigidbody> Rigidbodies;
        
        private void OnTriggerEnter(Collider other)
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb)
            {
                Rigidbodies.Add(rb);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null) Rigidbodies.Remove(rb);
        }

    }
}