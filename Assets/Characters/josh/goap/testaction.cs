using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testaction : joshgoapaction
{
    bool woken = false;
    testaction()
    {
        AddPre("awake", false);
        AddPost("awake", true);
    }
    public override bool Actiondone()
    {
        return woken;
    }

    public override bool CheckPreconditions()
    {
        return true;
    }

    public override bool ActionMethod(GameObject agent)
    {
        Debug.Log("wake");
        agent.GetComponent<joshgoapagent>().awake = true;
        woken = true;
        return true;
    }
}
