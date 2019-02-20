using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

namespace Kail
{

    public class Radar : MonoBehaviour
    {
        public bool targetFound;
        public MyGuyController current;
        
        public GameObject seenTarget;
        public GameObject posTarget;

        public float tarDistance;

        public void OnTriggerEnter(Collider other)
        {

            current = GetComponent<MyGuyController>();
            
            
            
            seenTarget = other.gameObject;
            
            if (seenTarget.GetComponent<CharacterBase>() != null)
            {
                if (targetFound == false)
                {
                    posTarget = seenTarget;
                    CheckTarget();
                }
            }

        }

        private void CheckTarget()
        {
            //these things only happen if player is on idle
            if (current.currentState == current.idleState)
            {
                current.currentState.MoveStop();


                var tempVec = posTarget.transform.position;
                tempVec = new Vector3(0f, tempVec.y, 0f);

                transform.LookAt(tempVec);

                //sets the roation.x to 0f, because i want that
                var tempRot = new Quaternion();
                tempRot.Set(0f, transform.rotation.y, 0f, 1);
                transform.rotation = tempRot;

                
                //checks if you can see the enemy
                var tempObj = new RaycastHit();

                if ((Physics.Linecast(transform.position, posTarget.transform.position, out tempObj)) && (tempObj.transform.gameObject == posTarget))
                {
                    //if yes target is now found and enemy is seen and now i have to figure out how to set things on the behaviour tree
                    targetFound = true;
                }
                else
                {
                    //otherwise character goes back to walking around
                    posTarget = null;
                    current.currentState.MoveSet();
                }
            }
        }


        private void OnTriggerStay(Collider other)
        {
            if ((other.gameObject == posTarget) && (targetFound == true))
            {
                tarDistance = Vector3.Distance(posTarget.transform.position, transform.position);
            }
        }

        public void TargetNotFound()
        {
            targetFound = false;
        }
    }
    
}