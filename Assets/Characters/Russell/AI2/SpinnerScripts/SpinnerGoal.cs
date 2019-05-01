using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;

namespace Russell
{
    public class SpinnerGoal : ReGoapGoal<string,object>
    {
        protected override void Awake()
        {
            base.Awake();
            goal.Set("EnemyDamaged", true);
        }
    }


}
