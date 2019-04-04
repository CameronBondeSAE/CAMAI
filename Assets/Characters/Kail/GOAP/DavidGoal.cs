using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;

namespace Kail
{
    public class DavidGoal : ReGoapGoal<string, object>
    {
        protected override void Awake()
        {
            base.Awake();
            goal.Set("childHappy", true);
        }
    }
}