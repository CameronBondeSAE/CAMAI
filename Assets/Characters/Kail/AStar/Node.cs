using System.Collections;
using System.Collections.Generic;
using NodeCanvas.Tasks.Actions;
using UnityEngine;

namespace Kail
{

    public class Node
    {
        public bool blocked = false;  //if theres something on the node or not
        
        //path related
        public float endCost; //how far the node is from the end
        public float pathCost; //total cost of the path so far
        public float totalCost; //pathCost + distCost
        
        public Node parentNode; //the node before that led to this one
        
        //position related
        public Vector3 nodePos; //where the node is
        public int xPos; //the x position of the node
        public int yPos; //the y position of the node
    }
    
}