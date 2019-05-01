using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;

namespace Russell
{
    public class SpinnerMemory : ReGoapMemory<string,object>
    {
        // Start is called before the first frame update
        protected override void Awake()
        {
            base.Awake();
            GetWorldState().Set("hasTarget", false);
            GetWorldState().Set("haveMoved", false);
            GetWorldState().Set("alive", true);
            GetWorldState().Set("targetKilled", false);
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }


}
