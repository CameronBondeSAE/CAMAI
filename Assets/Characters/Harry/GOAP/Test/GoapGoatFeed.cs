using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;

namespace Harry
{
    
    public class GoapGoatFeed : ReGoapGoal<string, object>
    {
        protected override void Awake()
        {
            base.Awake();
            // finish requirements
            goal.Set("isFed", true);
        }
    }

}


