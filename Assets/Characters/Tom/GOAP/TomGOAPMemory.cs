using System.Collections;
using System.Collections.Generic;
using ReGoap.Core;
using ReGoap.Unity;
using UnityEngine;

public class TomGOAPMemory : ReGoapMemory<string, object>
{
    public bool canCry = false;
    public bool hasChuggedWater = false;
    public bool hasSippedWater = false;

    protected override void Awake()
    {
        base.Awake();
        GetWorldState().Set("canCry", canCry); // Normal Unity inspector for initial value
        GetWorldState().Set("hasChuggedWater", hasChuggedWater); // Normal Unity inspector for initial value
        GetWorldState().Set("hasSippedWater", hasSippedWater); // Normal Unity inspector for initial value
    }
}

