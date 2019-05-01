using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomGOAPCryAction1 : TomGOAPCry
{
    protected override void Awake()
    {
        base.Awake();
        preconditions.Set("hasChuggedWater", true);
        effects.Set("canCry", true);
    }
}
