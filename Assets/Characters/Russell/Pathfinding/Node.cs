using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Russell
{
    public class Node
    {
        public int gCost;
        public int hCost;
        public int fCost;
        public bool isBlocked;
        public Node parentNode;
    
    }
}
