using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;

namespace Michael
{
    public class GOATMemory : ReGoapMemory<string,object>
    {
        public bool isHungry;
        public bool energy;
        public bool walked;
        protected override void Awake()
        {
            base.Awake();
            GetWorldState().Set("hungry", isHungry);
            GetWorldState().Set("hasEnergy", energy);
            GetWorldState().Set("walked", walked);
        }
    }
}
