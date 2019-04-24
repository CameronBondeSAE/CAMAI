using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;

public class BuilderGoal : ReGoapGoal<string, object>
{
    protected override void Awake()
    {
        base.Awake();
        goal.Set("houseBuilt", true);
    }
}
