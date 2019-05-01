using System.Collections;
using System.Collections.Generic;
using ReGoap.Core;
using ReGoap.Unity;
using UnityEngine;
//THIS SCRIPT CHANGES THE PRE CONDITIONS
public class TomGOAPAgent : ReGoapAgent<string, object>
{
    
    public int hasSippedWater = 0;
    
    private void Update()
    {

        // TODO: Debug cheat
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(CryDuration());

        }
        
        
        if (Input.GetKeyDown(KeyCode.A))
        {

            hasSippedWater ++;
        }

        if (hasSippedWater >= 10)
        {
            GetMemory().GetWorldState().Set("hasSippedWater", true);
            CalculateNewGoal(true);
        }
         
        
        
    }

    IEnumerator CryDuration()
    {
        GetMemory().GetWorldState().Set("hasChuggedWater", true);
        CalculateNewGoal(true);
        yield return new WaitForSeconds(2.0f);
        GetMemory().GetWorldState().Set("canCry", false);
        GetMemory().GetWorldState().Set("hasChuggedWater", false);
        //CalculateNewGoal(true);
        GetComponent<Renderer>().material.color = Color.white;
        
    }
}

