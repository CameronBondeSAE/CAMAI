using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;

public class BuilderMemory : ReGoapMemory<string, object>
{
    protected override void Awake()
    {
        base.Awake();
        GetWorldState().Set("treeFound", false);
        GetWorldState().Set("hasAxe", false);
        GetWorldState().Set("hasWood", false);
        GetWorldState().Set("treeFound", false);
        GetWorldState().Set("hasAxe", false);
        GetWorldState().Set("hasHammer", false);
        GetWorldState().Set("WoodCollected", false);
        GetWorldState().Set("houseBuilt", false);
    }
}
