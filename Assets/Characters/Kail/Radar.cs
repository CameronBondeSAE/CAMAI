using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kail
{

    public class Radar : MonoBehaviour
    {
        public bool targetFound;
        public StateBase current;
        public GameObject posTarget;

        public void OnTriggerEnter(Collider other)
        {

            posTarget = other.gameObject;
            if ((posTarget.GetComponent<CharacterBase>() != null) & (targetFound != true))
            {
                Vector3 tempVec = posTarget.transform.position;
                tempVec = new Vector3(0f, tempVec.y, 0f);
                
                transform.LookAt(tempVec);
                
                
                
                //then turn to them and raycast
                //if you can see them
            }

        }

        private void OnTriggerStay(Collider other)
        {
            if (posTarget.GetComponent<CharacterBase>() == null)
            {
                //then check distance
                //if you're close turn
                
            }
        }

        public void TargetNotFound()
        {
            targetFound = false;
        }
    }
    
}