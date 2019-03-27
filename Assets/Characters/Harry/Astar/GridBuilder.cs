using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace Harry
{

    public class GridBuilder : MonoBehaviour
    {

        public Vector3 startPoint;
        public Vector3 endPoint;
        public float xDist;
        private float xCheckSize;
        public float yDist;
        private float yCheckSize;

        public int resolution = 10;

        public int[,] map;

        // Start is called before the first frame update
        void Update()
        {
            map = new int[resolution,resolution];
            FindGrid();
        }

        private void FindGrid()
        {
            RaycastHit hit;
            Physics.Raycast(transform.position, Vector3.down, out hit, 100f);

            startPoint = hit.collider.bounds.min;
            endPoint = hit.collider.bounds.max;

            xDist = Mathf.Abs(endPoint.x - startPoint.x);
            yDist = Mathf.Abs(endPoint.z - startPoint.z);

            xCheckSize = xDist / resolution;
            yCheckSize = yDist / resolution;

            for (int i = 0; i < resolution; i++)
            {
                for (int j = 0; j < resolution; j++)
                {
                    Vector3 checkPos = new Vector3(startPoint.x + (xCheckSize * j), startPoint.y + 1, startPoint.z + (yCheckSize * i));
                    if (Physics.CheckBox(checkPos, new Vector3(xCheckSize / 2, 0.5f, yCheckSize / 2), Quaternion.identity))
                    {
                        map[j, i] = 1;
                        Debug.DrawRay(checkPos, Vector3.up, Color.red);
                    }
                    else
                    {
                        map[j, i] = 0;
                        Debug.DrawRay(checkPos, Vector3.up, Color.cyan);
                    }
                }
            }

        }

    }
   
}
