using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Russell
{
    public class Grid : MonoBehaviour
    {
        public Node[,] grid;
        public Vector2Int gridSize;
        public Vector3 startPos;
        public Vector3 endPos;
        public GameObject floor;

        private void Start()
        {
            grid = new Node[gridSize.x,gridSize.y];
            GenerateGrid();
        }

        public void GenerateGrid()
        {

           // startPos = floor.GetComponent<Collider>().bounds.min;
            //endPos = floor.GetComponent<Collider>().bounds.max;

            //float distanceX = Mathf.Abs(endPos.x - startPos.x);
            //float distanceY = endPos.z - startPos.z;
            
            
            for (int x = 0; x < gridSize.x; x++)
            {
                for (int y = 0; y < gridSize.y; y++)
                {
                    grid[x,y] = new Node();
                    //grid[x,y].position = 

                }
            }
        }


    }
}
