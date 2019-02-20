﻿using System;
using System.Collections;
using System.Collections.Generic;
using Russell;
using UnityEngine;

public class Kyllarr_Model : CharacterBase
{
    public event Action KillMove;
    public StateBase currentState;
    public StateBase attackState;
    public StateBase rotateState;
    public StateBase patrolState;
    public List<Collider> whosAround = new List<Collider>(); 

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
        patrolState = GetComponent<PatrolState>();
        //ChangeState(patrolState);
        currentState.Enter();
    }
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        
        //GetComponent<PatrolState>().OnDoneMoving += Kyllarr_Model_OnDoneMoving;
        //GetComponent<RotateState>().OnDoneRotating += Kyllarr_Model_OnDoneRotating;
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
    public void Attack()
    {
        Debug.Log("Attack");
    }
    public void Execute()
    {
        Debug.Log("Execute");
        
    }
    
    //Checking whos is within range and remove them if no longer in range
    //HACKY atm
    private void OnTriggerEnter(Collider other)
    {
        KillMove();
        if (!whosAround.Contains(other) && other.GetComponent<CharacterBase>())
        {
            whosAround.Add(other);
        }
    }
    private void OnTriggerExit(Collider other)
    { 
        whosAround.Remove(other);        
    }
}
