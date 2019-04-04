using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;

public class GaryGoapAgent : ReGoapAgent<string, object>
{
    
    protected override void Awake()
    {
        base.Awake();

        GetComponent<GaryGoapLOSSensor>().OnCanSeeEnemy += () => CalculateNewGoal(false);
    }
}
