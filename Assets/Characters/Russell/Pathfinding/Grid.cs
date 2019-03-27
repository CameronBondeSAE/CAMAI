using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Russell
{
    public class Grid : MonoBehaviour
    {
        public Node[,] grid;
        public int x;
        public int y;
        public Vector2Int gridSize;

        private void Start()
        {
            
        }

        public void GenerateGrid()
        {
            grid = new Node[gridSize.x,gridSize.y];
        }
    }
}
