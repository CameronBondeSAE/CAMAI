using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEditor;
using UnityEngine;

namespace Kail
{
    public class GridManager : MonoBehaviour
    {
        private GameObject floor;
        private Collider map;//the map
        private Vector3 boundsStart; //the starting part of the map
        private Vector3 boundsEnd; //the furthest point on the map
        private float xSize; //how big the mapbounds X is
        private float ySize; //how big the mapbounds Y is

        public int size = 55; //the size of the map grid, not dependant on the actual size of anything like above
        
        public Node[,] mapPoints; //the nodes on the map

        private void Awake()
        {
            //find the map
            RaycastHit hit;
            Physics.Raycast(transform.position, Vector3.down, out hit, 1000f);
            floor = hit.collider.gameObject;
            map = floor.GetComponent<Collider>();
            
            //make mapPoints
            mapPoints = new Node[size, size];
            
            //goto the function that makes the grid
            MakeGrid();


        }

        private void MakeGrid()
        {
            //set the bounds of the map
            boundsStart = map.bounds.min;
            boundsEnd = map.bounds.max;
            
            //set the size of the x/y of the map, in relation to the size
            xSize = Mathf.Abs(boundsEnd.x - boundsStart.x);
            ySize = Mathf.Abs(boundsEnd.z - boundsStart.z);

            xSize = xSize / size;
            ySize = ySize / size;

            //make the grid
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    //find current postion
                    Vector3 nodePosCheck = new Vector3(boundsStart.x + (xSize * j), boundsStart.y + 1, boundsStart.z + (ySize * i));
                    
                    //make new mapPoint and set current position
                    mapPoints[j, i] = new Node();
                    mapPoints[j, i].nodePos = nodePosCheck - Vector3.up;
                    mapPoints[j, i].xPos = j;
                    mapPoints[j, i].yPos = i;
                    
                    //physics check to see if something is blocking this node
                    if (Physics.CheckBox(nodePosCheck, new Vector3(xSize / 2, 0.5f, ySize / 2), Quaternion.identity))
                        mapPoints[j, i].blocked = true;
                    else mapPoints[j, i].blocked = false;
                    

                }
            }
        }

        private void OnDrawGizmos()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (mapPoints[j,i].blocked == true) Gizmos.color = Color.red;
                    else Gizmos.color = Color.grey;
                    
                    Gizmos.DrawCube(new Vector3(mapPoints[j,i].nodePos.x, mapPoints[j,i].nodePos.y + 1f, mapPoints[j,i].nodePos.z), Vector3.one);
                }
            }
        }

    }
}