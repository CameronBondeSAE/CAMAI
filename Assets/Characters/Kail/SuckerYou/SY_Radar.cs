using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Kail
{
    public class SY_Radar : MonoBehaviour
    {
        private SuckerYouController current;
        private SuckerYouMovement movement;

        public GameObject obj;

        private void Awake()
        {
            current = GetComponentInParent<SuckerYouController>();
            movement = GetComponentInParent<SuckerYouMovement>();
        }
        
        private void OnTriggerEnter(Collider other)
        {
            obj = other.gameObject;
            CharacterBase tar = GetComponent<CharacterBase>();
            
            if (tar != null)
            {
                //then this is your target, change to chase mode
            }
        }


    }
}