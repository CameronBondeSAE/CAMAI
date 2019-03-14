using System;
using System.Collections;
using System.Collections.Generic;
using Russell;
using UnityEngine;

public class Kyllarr_Model : CharacterBase
{
    public event Action KillMove;
    public event Action Killme;
    public event Action GotHurt;
    public StateBase currentState;
    public StateBase attackState;
    public StateBase rotateState;
    public StateBase patrolState;

    //public GameObject mainAi;
    
    public void ChangeState(StateBase newState)
    {
        //Check state is not the same
        currentState.Exit();
        newState.Enter();
        currentState = newState;
        Debug.Log("Ran Change State "+ newState);
    }

    private void Awake()
    { 
        //ChangeState(patrolState);
        currentState.Enter();
        GetComponent<Health>().OnDeathEvent += Kyllarr_Dies;
        GetComponent<Health>().OnHurtEvent += JustGotHurt;  
    }

    public void JustGotHurt()
    {
        if (GetComponent<DecoyMovement>() == null)
        {
            GotHurt();
        }
        
        
    }

    public void Kyllarr_Dies()
    {
        if (GetComponent<DecoyMovement>() == null)
        {
            Killme();
        }

    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

    }
    
    

    // Update is called once per frame
    public void Update()
    {
        currentState.Execute();

    }

    private void Kyllarr_Model_OnDoneMoving()
    {
        ChangeState(rotateState);
    }
    private void Kyllarr_Model_OnDoneRotating()
    {
        ChangeState(patrolState);
    }

    public void FanFire()
    {
        Debug.Log("FanFire");
    }

    public void DashAttack()
    {
        ChangeState(attackState);
        KillMove();
        
    }
    public void Attack()
    {
        Debug.Log("Attack");
    }
    public void Execute()
    {
        Debug.Log("Execute");
        
    }


}
