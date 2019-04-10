using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;

namespace Kail
{
    public class DavidGoalTwo : ReGoapGoal<string, object>
    {
        protected override void Awake()
        {
            base.Awake();
            goal.Set("childHealthy", true);
        }
    }
}