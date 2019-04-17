using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace Harry
{
    
    public class AstarManager : MonoBehaviour
    {
        public Node startNode;
        public Node targetNode;

        // continue = break except it only does it for one instance of a loop
        public List<Node> openNodes = new List<Node>();
        public List<Node> closedNodes = new List<Node>();

        public GridBuilder builder;

        private void Start()
        {
            FindPossiblePath();
            
        }

        public void FindPossiblePath()
        { 
            Node testStart = GetNode(Random.Range(0, builder.resolution), Random.Range(0, builder.resolution));

            while (testStart.occupied)
            {
                testStart = GetNode(Random.Range(0, builder.resolution), Random.Range(0, builder.resolution));
            }

            startNode = testStart;

            Node testEnd = GetNode(Random.Range(0, builder.resolution), Random.Range(0, builder.resolution));

            while (testEnd.occupied)
            {
                testEnd = GetNode(Random.Range(0, builder.resolution), Random.Range(0, builder.resolution));
            }

            targetNode = testEnd;

        }

        public Node GetNode(int x, int y)
        {
            return builder.map[x, y];
        }

        public void FindNeighbours(int x, int y)
        { 
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {

                }
            }


        }

    }
    
}

