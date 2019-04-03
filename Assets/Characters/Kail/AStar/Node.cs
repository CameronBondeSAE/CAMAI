using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kail
{

    public class Node
    {
        public bool blocked = false;  //if theres something on the node or not
        public Vector3 nodePos; //where the node is
        public float dist; //how far the node is from the end
        public Node parentNode; //the node before that led to this one
    }
    
}