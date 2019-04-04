using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;

namespace Michael
{
    public class GOATGoal : ReGoapGoal<string, object>
    {
        protected override void Awake()
        {
            base.Awake();
            goal.Set("walked", true);
            //goal.Set("hasEnergy", false);
        }
    }
}
