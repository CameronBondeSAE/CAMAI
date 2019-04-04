using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using NodeCanvas.Tasks.Actions;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;


namespace Kail
{
    public class SY_Radar : MonoBehaviour
    {
        private SuckerYouController current;
        private SuckerYouMovement movement;

        public GameObject radarObj;

        private Rigidbody rb;
        public int torque;

        

        private void Awake()
        {
            current = GetComponentInParent<SuckerYouController>();
            movement = GetComponentInParent<SuckerYouMovement>();
            rb = GetComponentInParent<Rigidbody>();
        }
        
        private void OnTriggerEnter(Collider other)
        {
            radarObj = other.gameObject;
            CharacterBase tar = radarObj.GetComponent<CharacterBase>();
            
            if (tar != null)
            {
                Debug.Log("got here"); //gets here but doesnt go any further
                movement.MoveOverride();
                current.target = radarObj;
                current.targetFound = true;
            }
        }

        private void FixedUpdate()
        {
            GameObject rayObj;
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out hit, 7f))
            {
                rayObj = hit.collider.gameObject;
                CharacterBase rayTar = rayObj.GetComponent<CharacterBase>();

                if (rayTar == null)
                {
                    rb.AddRelativeTorque(0, torque*2, 0);
                }
            }

            
            
            
        }
    }
}