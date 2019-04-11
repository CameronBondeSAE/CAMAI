using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;

namespace Kail
{
    public class HappyGoal : ReGoapGoal<string, object>
    {
        protected override void Awake()
        {
            base.Awake();
            Name = "HappyGoal";
            goal.Set("childHappy", true);
            Priority = 2; //default priority
        }
        
        public void SetPriority(int i)
        {
            Priority = i;
        }
    }
}