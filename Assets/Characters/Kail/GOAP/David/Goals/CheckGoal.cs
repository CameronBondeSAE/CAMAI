using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;

namespace Kail
{
    public class CheckGoal : ReGoapGoal<string, object>
    {
        protected override void Awake()
        {
            base.Awake();
            Name = "CheckGoal";
            goal.Set("checkChild", true);
        }
    }
}