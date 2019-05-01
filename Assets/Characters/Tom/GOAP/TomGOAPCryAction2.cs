using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomGOAPCryAction2 : TomGOAPCry
{
    protected override void Awake()
    {
        base.Awake();
        preconditions.Set("hasSippedWater", true);
        effects.Set("canCry", true);
    }
}
