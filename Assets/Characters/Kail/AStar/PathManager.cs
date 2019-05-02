using System.Collections;
using System.Collections.Generic;
using NodeCanvas.Tasks.Actions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Kail
{
    public class PathManager : MonoBehaviour
    {
        //the grid
        private GridManager grid;
        
        //the start/end objects
        public GameObject mover;
        public GameObject target;
        
        //node lists
        public List<Node> openNodes = new List<Node>();
        public List<Node> usedNodes = new List<Node>();
        private List<Node> path = new List<Node>();

        //node locations
        private Node current;
        private Node start;
        private Node end;

        //are we there yet?
        private bool thereYet;
        
        private void Awake()
        {
            grid = GetComponent<GridManager>();
            mover = GameObject.FindWithTag("Player");
            target = GameObject.FindWithTag("Finish");
        }

        private void Start()
        {
            StartCoroutine(StartFindPath());
        }

        private IEnumerator StartFindPath()
        {
            yield return new WaitForSeconds(1);
            //set start location, making sure to reset if blocked
            start = grid.mapPoints[(int)Random.Range(0, grid.size), (int)Random.Range(0, grid.size)];
            if (start.blocked) start = grid.mapPoints[(int)Random.Range(0, grid.size), (int)Random.Range(0, grid.size)];
            //set mover to be at start
            mover.transform.position = new Vector3(start.nodePos.x, start.nodePos.y + 1, start.nodePos.z);
            
            //set end location, making sure to reset if blocked
            end = grid.mapPoints[(int)Random.Range(0, grid.size), (int)Random.Range(0, grid.size)];
            if (end.blocked) end = grid.mapPoints[(int)Random.Range(0, grid.size), (int)Random.Range(0, grid.size)];
            //set target to be at end
            target.transform.position = new Vector3(end.nodePos.x, end.nodePos.y + 1, end.nodePos.z);
            
            //and we begin
            
            openNodes.Add(start);
            current = start;
            yield return new WaitForSeconds(1);
            while (current != end)
            {
                FindPath();
                yield return new WaitForSeconds(.01f);
            }
            
            //once it reaches the target, set the actual path
            Node pathNext = end;
            while (pathNext.parentNode != null)
            {
                path.Add(pathNext);
                pathNext = pathNext.parentNode;
            }
            path.Reverse();
            StartCoroutine(Pause());


        }

        public void FindPath()
        {
            //take the current node off of openNodes, because it's being used
            if (openNodes.Contains(current)) openNodes.Remove(current);

            for (var x = -1; x < 2; x++)
            for (var y = -1; y < 2; y++)
            {
                //set all positions that should be ignored
                if (x == 0 && y == 0) continue;
                if (((current.xPos + x) < 0) || (current.xPos + x) > (grid.size - 1)) continue;
                if (((current.yPos + y) < 0) || (current.yPos + y) > (grid.size - 1)) continue;

                //set positions that shouldn't be ignored
                Node neighbour = grid.mapPoints[current.xPos + x, current.yPos + y];

                //unless that position SHOULD be ignored
                if ((neighbour.blocked) || usedNodes.Contains(neighbour)) continue;

                //calc floats for neighbour node
                float dist = Mathf.Abs(x) + Mathf.Abs(y) > 1 ? 1.4f : 1;
                float endCost = Vector2.Distance(neighbour.nodePos, end.nodePos);
                
                float pathCost = current.pathCost + dist;
                float newTotalCost = endCost + pathCost;

                //set floats for neighbour node
                neighbour.parentNode = current;
                neighbour.endCost = endCost;
                neighbour.pathCost = pathCost;
                neighbour.totalCost = newTotalCost;

                //add neighbour to the openNodes list, so long as its not on there already
                if (!openNodes.Contains((neighbour))) openNodes.Add(neighbour);
            }

            //add current to the usedNodes list, so long as its not on there already
            if (!usedNodes.Contains(current)) usedNodes.Add(current);
            ChoosePath();
        }

        public void ChoosePath()
        {
            Node maybe = new Node();
            maybe.totalCost = float.MaxValue;

            //find the node with the lowest cost
            foreach (Node node in openNodes)
            {
                if (maybe.totalCost > node.totalCost) maybe = node;
            }
               
            //set current to the node with the lowest cost
            current = maybe;
        }


        private IEnumerator Pause()
        {
            foreach (var node in path)
            {
                yield return new WaitForSeconds(0.1f);
                mover.transform.position = new Vector3(node.nodePos.x, node.nodePos.y + 1, node.nodePos.z);
            }
            thereYet = true;
            Reload();
        }


        private void OnDrawGizmos()
        {
            
            if (current != null)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawCube(new Vector3(current.nodePos.x, current.nodePos.y + 1, current.nodePos.z), Vector3.one);
            }

            if (openNodes != null)
            {
                foreach (Node node in openNodes)
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawCube(new Vector3(node.nodePos.x, node.nodePos.y + 1, node.nodePos.z), Vector3.one);
                }
            }

            if (usedNodes != null)
            {
                foreach (Node node in usedNodes)
                {
                    Gizmos.color = Color.black;
                    Gizmos.DrawCube(new Vector3(node.nodePos.x, node.nodePos.y + 1, node.nodePos.z), Vector3.one);
                }

                foreach (Node node in path)
                {
                    Gizmos.color = Color.green;
                    Gizmos.DrawCube(new Vector3(node.nodePos.x, node.nodePos.y + 1, node.nodePos.z), Vector3.one);
                }
            }
        }

        void Reload()
        {
            int restart = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(restart);
        }
    }
}