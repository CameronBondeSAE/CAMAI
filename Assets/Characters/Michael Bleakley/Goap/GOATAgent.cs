using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;

namespace Michael
{
    public class GOATAgent : ReGoapAgent<string,object>
    {
        private void Update()
        {
            if (Input.anyKey)
            {
                CalculateNewGoal(true);
            }
        }
    }
}