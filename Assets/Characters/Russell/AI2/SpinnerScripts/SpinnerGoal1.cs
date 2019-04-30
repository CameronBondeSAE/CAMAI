using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;

namespace Russell
{
    public class SpinnerGoal1 : ReGoapGoal<string,object>
    {
        // Start is called before the first frame update
        protected override void Awake()
        {
            base.Awake();
            goal.Set("hasTarget", true);
        }
    }


}
