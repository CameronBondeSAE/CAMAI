using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;

namespace Kail
{
    public class HealthyGoal : ReGoapGoal<string, object>
    {
        protected override void Awake()
        {
            base.Awake();
            Name = "HealthyGoal";
            goal.Set("childHealthy", 10);
            Priority = 3; //default priority
        }
    }
}