using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Russell
{
    public class AStar : MonoBehaviour
    {
        public List<Node> openNodes = new List<Node>();
        public List<Node> closedNodes = new List<Node>();
        public Grid gridManager;
        private Node currentPos;
        private Node nb;
        private Node target;
        public GameObject start;
        public GameObject end;

        // Start is called before the first frame update
        void Start()
        {
            gridManager = GetComponent<Grid>();
            currentPos = gridManager.grid[Random.Range(0, gridManager.gridSize.x),
                Random.Range(0, gridManager.gridSize.y)];
            target = gridManager.grid[Random.Range(0, gridManager.gridSize.x),
                Random.Range(0, gridManager.gridSize.y)];



        }

        public void LowestFCost()
        {
            Node checkNode = new Node();
            checkNode.fCost = float.MaxValue;

            foreach (Node node in openNodes)
            {
                if (checkNode.fCost > node.fCost)
                {
                    checkNode = node;
                }
            }

            currentPos = checkNode;
        }

        public void FindPath()
        {
            for (int x = -1; x < 2; x++)
            {
                for (int y = -1; y < 2; y++)
                {
                    if (x != 0 && y != 0)
                    {

                        if ((int) (currentPos.position.x + x) < 0 ||
                            (int) (currentPos.position.x + x) > gridManager.gridSize.x - 1) continue;
                        if ((int) (currentPos.position.y + y) < 0 ||
                            (int) (currentPos.position.y + y) > gridManager.gridSize.y - 1) continue;
                        nb = (gridManager.grid[(int) (currentPos.position.x + x), (int) (currentPos.position.y + y)]);
                        float dist;
                        dist = Mathf.Abs(x) + Mathf.Abs(y) > 1 ? 1.4f : 1;
                        if (!nb.isBlocked && !closedNodes.Contains(nb))
                        {
                            nb.parentNode = currentPos;
                            nb.hCost = (Vector2.Distance(nb.position, target.position));
                            nb.gCost = nb.parentNode.gCost + dist;
                            float newFCost;
                            newFCost = nb.hCost + nb.gCost;
                            if (nb.fCost < newFCost) continue;
                            nb.fCost = newFCost;
                            if(!openNodes.Contains(nb))
                            openNodes.Add(nb);
                            if(!closedNodes.Contains(currentPos))
                            closedNodes.Add(currentPos);

                        }
                    }

                }
            }
            LowestFCost();
        }

        // Update is called once per frame
        void Update()
        {
            while (currentPos != target)
            {
                //FindPath();
            }

           
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawCube(new Vector3(gridManager.grid[(int)currentPos.position.x,(int)currentPos.position.y].position.x, gridManager.grid[(int)currentPos.position.x,(int)currentPos.position.y].position.y,gridManager.grid[(int)currentPos.position.x,(int)currentPos.position.y].position.z), Vector3.one);
        }
    }
}


        

