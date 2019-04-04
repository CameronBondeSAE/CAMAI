using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;

public class GaryGoapMemory : ReGoapMemoryAdvanced<string, object>
{
    protected override void Awake()
    {
        base.Awake();
        
        GetWorldState().Set("isHidden", false);
        GetWorldState().Set("canSeeTarget", false);
    }
}
