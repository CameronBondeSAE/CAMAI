using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kail
{

    public class StateBase : MonoBehaviour
    {
        
        public virtual void Enter()
        {
            //what happens when the ai enters the state
        }

        public virtual void Update()
        {
            //what happens while the ai is in the state
        }
        
        public virtual void MoveSet()
        {
            //how the state effects movement
        }
        
        public virtual void MoveEnd()
        {
            //what happens once movement has ended
        }

        public virtual void MoveStop()
        {
            //what happens when the movement is forced to stop
        }
        
        public virtual void Exit()
        {
            //what happens when the ai leaves the state
        }

        
        
        
    }
}