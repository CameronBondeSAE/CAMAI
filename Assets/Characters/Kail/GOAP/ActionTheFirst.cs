using System;
using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;

public class ActionTheFirst : ReGoapAction<string, object>
{
    protected override void Awake()
    {
        base.Awake();
        preconditions.Set("atfCondition", true);
        effects.Set("atfEffect", true);
    }
}
