using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReGoap.Unity;

namespace Harry
{
    
    public class BuilderAgent : ReGoapAgent<string, object>
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<BuilderMemory>().Reset();
                CalculateNewGoal(true);
            }
        }
    }
    
}

