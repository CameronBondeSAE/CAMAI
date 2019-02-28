using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Kail
{
    public class MyGuyMovement : MonoBehaviour
    {
        public Rigidbody rb;
        public int time = 0;
        public float speed;

        public bool timeEnd;
        public bool moveStop;
        public StateBase currentState;

        public CharacterBase speedBase;


        public void MoveStart(StateBase theState, float theSpeed, int theTime)
        {

            speedBase = GetComponent<CharacterBase>();
            
            currentState = theState;
            speed = theSpeed * speedBase.SpeedMultiplier;
            time = theTime;
            timeEnd = false;
            moveStop = false;
            rb = GetComponent<Rigidbody>();
        }
        
        public void MoveStop()
        {
            //sends the player to the end state of movement for its current state
            
            time = 0;
            timeEnd = true;
            currentState.MoveEnd();
        }

        public void MoveOverride()
        {
            //stops the movement if told to, even if there is still time left
            moveStop = true;
        }

        void FixedUpdate()
        {
            //moves the player, so long as there is time left to
            if (moveStop == true)
            {
                //do nothing
            }
            else
            {
                if (time <= 0)
                {
                    if (timeEnd == false)
                    {
                        MoveStop();
                    }
                    else
                    {
                        //do nothing
                    }
                }
                else
                {
                    transform.position += transform.forward * speed * Time.deltaTime;
                    time = time - 1;
                }
            }
        }
    }
}