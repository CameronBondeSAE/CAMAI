using System.Collections;
using System.Collections.Generic;
using Russell;
using UnityEngine;

public class Kyllarr_Model : CharacterBase
{


    public StateBase currentState;
    public StateBase attackState;
    public StateBase rotateState;
    public StateBase patrolState;
    

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
        
        GetComponent<PatrolState>().OnDoneMoving += Kyllarr_Model_OnDoneMoving;
        GetComponent<RotateState>().OnDoneRotating += Kyllarr_Model_OnDoneRotating;
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
}
