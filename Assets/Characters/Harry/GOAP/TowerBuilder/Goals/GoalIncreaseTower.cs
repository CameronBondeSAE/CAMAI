using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;

public class GoalIncreaseTower : ReGoapGoal<string, object>
{
    protected override void Awake()
    {
        base.Awake();
        // finish requirements
        goal.Set("HeightIncreased", true);
        Debug.Log("Success");
    }
    
}
