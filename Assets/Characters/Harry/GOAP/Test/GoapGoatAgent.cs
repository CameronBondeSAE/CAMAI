using System.Collections;
using System.Collections.Generic;
using NodeCanvas.Tasks.Conditions;
using ReGoap.Unity;
using UnityEngine;

namespace Harry
{
    
    public class GoapGoatAgent : ReGoapAgent<string, object>
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetMemory().GetWorldState().Set("isFed", false);
                GetMemory().GetWorldState().Set("FoodNearby", false);
                CalculateNewGoal(true);
            }
        }
    }

}

