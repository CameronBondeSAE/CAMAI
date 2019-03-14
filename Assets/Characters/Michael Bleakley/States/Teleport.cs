using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Michael
{
    public class Teleport : StateBase
    {
        [SerializeField] int cost;
      [SerializeField] Vector3 destination;
     [SerializeField] Vector3 previousPosition;
     public int destinationRange;

     private void Start()
     {
         //assure that there is a safe place to teleport to if fallen off the map
         previousPosition = Self.transform.position;
     }

     public override void Enter()
        {
            destination = new Vector3(Random.Range(-destinationRange, destinationRange),transform.position.y,Random.Range(-destinationRange, destinationRange));
            destination += Self.transform.position;
            Invoke("teleport",delay);
            Debug.Log("Testing Entry");
        }

        public override void Execute()
        {
            base.Execute();
            if (transform.position.y < -1)
            {
                Debug.Log("Testing teleport");
                if (previousPosition != new Vector3())
                {
                    destination = previousPosition;
                }
                else
                {
                    destination = new Vector3(Random.Range(-destinationRange, destinationRange), 2,
                        Random.Range(-destinationRange, destinationRange));
                    destination.x += Self.transform.position.x;
                    destination.z += Self.transform.position.z;
                }
            }
        }  
        
        private void teleport()
        {
            Self.transform.position = destination;
            Self.GetComponent<Energy>().Change(-cost);
            Exit();
        }
    }
}
