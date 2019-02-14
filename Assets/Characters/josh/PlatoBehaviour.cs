using System.Collections;
using System.Collections.Generic;
using Josh;
using UnityEngine;

public class PlatoBehaviour : Josh.StateMachine
{
    public CharacterBase target;
    
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
