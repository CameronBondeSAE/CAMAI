using System.Collections;
using System.Collections.Generic;
using ReGoap.Core;
using ReGoap.Unity;
using UnityEngine;

namespace Harry
{
    
    public class GoapGoatMemory : ReGoapMemory<string, object>
    {
        public override ReGoapState<string, object> GetWorldState()
        {
            return base.GetWorldState();
        }
    }

}