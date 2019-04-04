﻿using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;

namespace Kail
{
    public class DavidMemory : ReGoapMemory<string, object>
    {
        public bool isHappy;

        protected override void Awake()
        {
            base.Awake();
            GetWorldState().Set("childHappy", isHappy);
        }
    }
}
