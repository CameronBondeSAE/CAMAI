using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Michael
{
    public class Teleport : StateBase
    {
    
     private Vector3 destination;
     private Vector3 previousPosition;
     public int destinationRange;
            
        public override void Enter()
        {
            previousPosition = transform.position;
            destination = new Vector3(Random.Range(-destinationRange, destinationRange),transform.position.y,Random.Range(-destinationRange, destinationRange));
            destination += transform.position;
            Invoke("teleport", delay);
        }

        public override void Execute()
        {
            base.Execute();
            if (transform.position.y < 0){
            transform.position = previousPosition;
            }
        }

        public override void Exit()
        {
            base.Exit();
        }    
        
        private void teleport()
        {
            transform.position = destination;
        }
    }
}
