using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Russell
{
    public class Node
    {
        public float gCost;
        public float hCost;
        public float fCost;
        public bool isBlocked;
        public Node parentNode;
        public Vector3 position;
        

    }
}
