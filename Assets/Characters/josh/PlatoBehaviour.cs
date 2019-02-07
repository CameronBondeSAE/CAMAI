using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Josh;

public class PlatoBehaviour : CharacterBase
{
    public StateBase currentstate;

    public void ChangeState(StateBase newstate)
    {
        //check newstate is not current state
        if (newstate != currentstate)
        {
            if(currentstate) currentstate.Exit();
            currentstate = newstate;
            currentstate.Enter();
        }
    }
    public override void Start()
    {
        base.Start();

        GetComponent<Health>().OnHurtEvent += PlatoBehaviour_OnHurtEvent;
        GetComponent<Health>().OnDeathEvent += PlatoBehaviour_OnDeathEvent;
    }

    private void Update()
    {
        currentstate.Execute();
    }

    private void PlatoBehaviour_OnDeathEvent()
    {
        Debug.Log("killed",gameObject);
        Destroy(gameObject);
    }

    private void PlatoBehaviour_OnHurtEvent()
    {
        Debug.Log("hit",gameObject);
    }
}
