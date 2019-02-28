using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Michael
{
    public class VestraTargeting : MonoBehaviour
    {
        private GameObject closest;

        public GameObject CheckDistance(List<GameObject> enemies)
        {
            foreach (var VARIABLE in enemies)
            {
                if (closest == null)
                {
                    closest = VARIABLE;
                }
                else if (Vector3.Distance(transform.position, closest.transform.position) >
                         Vector3.Distance(transform.position, VARIABLE.transform.position))
                {
                    closest = VARIABLE;
                }
            }
            return closest;
        }
    }
}
