using System.Collections;
using System.Collections.Generic;
using Kail;
using NodeCanvas.Tasks.Actions;
using UnityEngine;

namespace Kail
{
    public class PathManager : MonoBehaviour
    {
        private GridManager map;
        public List<Node> path;

        //where the searcher starts and where it needs to go
        private GameObject startPos;
        private GameObject endPos;
        
        //the current node
        private Node current;

        private void Awake()
        {
            map = GameObject.FindWithTag("manager").GetComponent<GridManager>();
            startPos = GameObject.FindWithTag("start");
            //insert stuff to find the location of this node
            endPos = GameObject.FindWithTag("end");
            //insert stuff to fine the location of this node, set it as current node
            path = new List<Node>();
        }
    }
}