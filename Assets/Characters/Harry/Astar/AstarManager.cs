using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace Harry
{
    
    public class AstarManager : MonoBehaviour
    {
        public Vector3 startPosition;
        public Vector3 target;

        // continue = break except it only does it for one instance of a loop
        public List<Node> openNodes = new List<Node>();
        public List<Node> closedNodes = new List<Node>();

        public Node[,] map;

        private void Awake()
        {
            
        }

        public void FindStart()
        {
            
        }

    }
    
}

