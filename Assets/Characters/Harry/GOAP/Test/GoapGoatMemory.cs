using System.Collections;
using System.Collections.Generic;
using ReGoap.Core;
using ReGoap.Unity;
using UnityEngine;

namespace Harry
{
    
    public class GoapGoatMemory : ReGoapMemory<string, object>
    {
        public bool isFedTest = false;

        protected override void Awake()
        {
            base.Awake();
            // setting world state for testing
            GetWorldState().Set("isFed", isFedTest);
        }

        public override ReGoapState<string, object> GetWorldState()
        {
            return base.GetWorldState();
            
        }
    }

}