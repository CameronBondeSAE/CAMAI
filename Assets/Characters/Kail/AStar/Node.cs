using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kail
{

    public class Node
    {
        public bool blocked = false;  //if theres something on the node or not
        
        public bool start = false; //if this is where the searcher started
        public bool end = false; //if this is the target position
        public bool passed = false; //if the searcher has already been here
        
        public Vector3 nodePos; //where the node is
        public float dist; //how far the node is from the end
        public Node parentNode; //the node before that led to this one
        public int xPos; //the x position of the node
        public int yPos; //the y position of the node
    }
    
}