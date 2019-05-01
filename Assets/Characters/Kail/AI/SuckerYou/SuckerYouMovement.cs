using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kail
{
    public class SuckerYouMovement : MonoBehaviour
    {

        private Rigidbody rb;
        public int time;
        private float speed;

        private bool timeEnd;
        
        //private CharacterBase speedBase;
        private StateBase currentState;
        private SuckerYouController state;

        void Awake()
        {
            //collect all the things you always need
            //speedBase = GetComponent<CharacterBase>();
            rb = GetComponent<Rigidbody>();
            state = GetComponent<SuckerYouController>();

        }

        public void MoveSet(float theSpeed, int theTime, StateBase theState)
        {
            
            //set up information for movement
            speed = theSpeed;
            time = theTime;
            
            //reset timeend
            timeEnd = false;
            
            //remember where we are
            currentState = theState;
        }

        public void MoveStop()
        {
            //make SY stop moving, then send them back to the state
            time = 0;
            timeEnd = true;
            currentState.MoveEnd();
        }

        public void MoveOverride()
        {
            //make SY stop moving
            time = 0;
            timeEnd = true;
        }
        
        private void FixedUpdate()
        {
            if (time <= 0)  //dont move if time is 0
            {
                if (timeEnd) ; //do nothing
                else MoveStop();  //go through MoveStop because you haven't yet
                
            }
            else //move
            {
                transform.position += transform.forward * speed * Time.deltaTime;
                time -= 1;
            }
        }
    }
}