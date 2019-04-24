using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;

public class BuildHouseAction : ReGoapAction<string,object>
{
    protected override void Awake()
    {
        base.Awake();
        preconditions.Set("hasHammer", true);
        preconditions.Set("WoodCollected", true);
        effects.Set("houseBuilt", true);
    }
}
