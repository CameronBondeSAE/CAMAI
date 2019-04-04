using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;

namespace Harry
{
    
    public class BuilderMemory : ReGoapMemory<string,object>
    {

        public int remainingWood = 0;
        public int remainingBlocks = 0;
        
        protected override void Awake()
        {
            base.Awake();
            // setting world state for testing
            GetWorldState().Set("TreeAvailable", false);
            GetWorldState().Set("TreePlanted", false);
            GetWorldState().Set("HaveNails", false);
            GetWorldState().Set("HaveWood", false);
            GetWorldState().Set("BlockAvailable", false);
            GetWorldState().Set("HaveBlock", false);
            GetWorldState().Set("HeightIncreased", false);
        }

        public void Reset()
        {
            GetWorldState().Set("HeightIncreased", false);
        }
    }


}

