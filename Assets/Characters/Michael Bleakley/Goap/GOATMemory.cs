﻿using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;

namespace Michael
{
    public class GOATMemory : ReGoapMemory<string,object>
    {
        public bool isHungry;

        protected override void Awake()
        {
            base.Awake();
            GetWorldState().Set("hungry", isHungry);
        }
    }
}
