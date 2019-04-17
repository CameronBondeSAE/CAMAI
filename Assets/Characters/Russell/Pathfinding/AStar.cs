using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Russell
{
    public class AStar : MonoBehaviour
    {
        public List<Node>openNodes = new List<Node>();
        public List<Node> closedNodes = new List<Node>();
        public Grid gridManager;
        private Node startpoint;
        private Node target;
        
        // Start is called before the first frame update
        void Start()
        {
            gridManager = GetComponent<Grid>();
            startpoint = gridManager.grid[Random.Range(0, gridManager.gridSize.x),
                Random.Range(0, gridManager.gridSize.y)];
            target = gridManager.grid[Random.Range(0, gridManager.gridSize.x),
                Random.Range(0, gridManager.gridSize.y)];
        }

        // Update is called once per frame
        void Update()
        {
            //Whileloop?
            //Scan Neighbours - foreach?
        }
    }


}
