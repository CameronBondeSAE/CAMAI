using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harry
{
    public class Node
    {
  
        public bool occupied = false;
        public Vector3 position = Vector3.zero;
        public float pathCost = 0;
        public float distCost = 0;
        public float totalCost = 0;
        public Node parentNode = null;

    }
}


