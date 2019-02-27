using System;
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
    public float numberOfPlayers;
    public ParticleSystem _particleSystem;
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
        
    }

    public void Kyllarr_Dies()
    {
        //Doesnt work quite yet but will finish soon
        GetComponent<Health>().OnDeathEvent -= Kyllarr_Dies;
        //_particleSystem.Play();
        Destroy(gameObject);
       
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
    
    //Checking whos is within range and remove them if no longer in range
    //HACKY atm
    private void OnTriggerEnter(Collider other)
    {
        
        if (!whosAround.Contains(other) && other.GetComponent<CharacterBase>())
        {
            whosAround.Add(other);
            numberOfPlayers = whosAround.Count;
        }
    }
    private void OnTriggerExit(Collider other)
    { 
        whosAround.Remove(other);  
        numberOfPlayers = whosAround.Count;
    }
}
