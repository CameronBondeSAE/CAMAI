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

        public bool look;

        public float tarDistance;

        public bool objChecking;
        public float objDistance;
        public GameObject obj;
        

        public void OnTriggerEnter(Collider other)
        {

            current = GetComponent<MyGuyController>();
            seenTarget = other.gameObject;
            
            if ((seenTarget.GetComponent<CharacterBase>() != null)  && (targetFound == false) && (seenTarget.GetComponent<MyGuyController>() == null))
            {
                    current.currentState.MoveStop();
                    posTarget = seenTarget;
                    LookAtEnemy();
            }

            

        }

        public void LookAtEnemy()
        {
            
            //transform.LookAt(posTarget.transform.position);

            //sets the rotation.x to 0f, because i want that
            var tempRot = new Quaternion();
            tempRot.Set(0f, transform.rotation.y - 180f, 0f, 1);
            transform.rotation = tempRot;

            if (current.currentState == current.idleState)
            {
                CheckTarget();
            }

            if (current.currentState == current.runState)
            {
                look = true;
                RunningAway();
            }

        }
        
        
        public void CheckTarget()
        {

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



        public void RunningAway()
        {
            //checks if you can see the enemy
            var tempObj = new RaycastHit();
            
            if ((Physics.Linecast(transform.position, posTarget.transform.position, out tempObj)) && (tempObj.transform.gameObject == posTarget))
            {
                //it sees the player
                tarDistance = Vector3.Distance(posTarget.transform.position, transform.position);
                current.currentState.MoveSet();
            }
            else
            {
                posTarget = null;
                targetFound = false;
            }
        }
        
        private void OnTriggerStay(Collider other)
        {
            /*if ((other.gameObject == posTarget) && (targetFound == true) && (current.currentState = current.idleState))
            {
                tarDistance = Vector3.Distance(posTarget.transform.position, transform.position);
            }*/

            if ((other.GetComponent<CharacterBase>() == null) && (current.currentState != current.runState))
            {
                obj = other.gameObject;
                objChecking = true;
            }
        }

        private void Update()
        {
            if (objChecking == true)
            {
                objDistance = Vector3.Distance(obj.transform.position, transform.position);
                if (objDistance >= 1.5f)
                {
                    objChecking = false;
                    current.currentState.MoveSet();
                }
            }
        }

        public void TargetNotFound()
        {
            targetFound = false;
        }
    }
    
}