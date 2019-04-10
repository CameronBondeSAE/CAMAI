using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class moveaction : joshgoapaction
{
    public NavMeshAgent mover;
    moveaction()
    {
        AddPre("attarget", false);
        AddPost("attarget", true);
    }

    private void Start()
    {
        //mover = gameObject.GetComponent<NavMeshAgent>();
    }

    public override bool Actiondone()
    {
        return Vector3.Distance(target.transform.position, gameObject.transform.position) < 0.5f;
    }

    public override bool CheckPreconditions()
    {
        target = gameObject.GetComponent<joshgoapagent>().target;
        return target!=null;
    }

    public override bool ActionMethod(GameObject agent)
    {
        Debug.Log("run move");
        mover.isStopped = false;
        mover.SetDestination(target.transform.position);
        return true;
    }
}
