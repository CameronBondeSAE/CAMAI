using System;
using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;

public class GaryGoapLOSSensor : ReGoapSensor<string, object>
{
    
    public Transform target;
    
    RaycastHit hitInfo;

    public event Action OnCanSeeEnemy;

    private bool previousCanSeeTarget = false;
    
    public override void UpdateSensor()
    {
        base.UpdateSensor();

        if (Physics.Linecast(transform.position, target.position, out hitInfo))
        {
            // Hit target
            if (hitInfo.transform == target)
            {
                GetMemory().GetWorldState().Set("canSeeTarget", true);
//                if (!previousCanSeeTarget)
                {
                    OnCanSeeEnemy?.Invoke();                    
                }
                previousCanSeeTarget = true;
            }
            else
            {
                GetMemory().GetWorldState().Set("canSeeTarget", false);            
                GetMemory().GetWorldState().Set("isHidden", false);            
                previousCanSeeTarget = false;
            }
        }
    }
}
