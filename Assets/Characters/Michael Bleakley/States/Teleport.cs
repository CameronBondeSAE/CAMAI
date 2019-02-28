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
            destination += Self.transform.position;
            Invoke("teleport", delay);
            Invoke("Exit", delay + 1);
        }

        public override void Execute()
        {
            base.Execute();
            if (transform.position.y < 0){
                if (previousPosition != new Vector3()) transform.position = previousPosition;
                destination = new Vector3(Random.Range(-destinationRange, destinationRange),2,Random.Range(-destinationRange, destinationRange));
                destination.x += Self.transform.position.x;
                destination.z += Self.transform.position.z;
            }
        }  
        
        private void teleport()
        {
            Self.transform.position = destination;
        }
    }
}
