using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testaction : joshgoapaction
{
    private float timer = 0;
    testaction()
    {
        AddPre("awake", false);
        AddPost("awake", true);
    }
    public override bool Actiondone()
    {
        return timer >= 5f;
    }

    public override bool CheckPreconditions()
    {
        return true;
    }

    public override bool ActionMethod(GameObject agent)
    {
        Debug.Log("wake");
        if (timer < 5)
        {
            timer += Time.deltaTime;
        }
        else
        {
            agent.GetComponent<joshgoapagent>().awake = true;
        }
        return true;
    }
}
